using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sendgrid_API_Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly string _apiKey = "SENDGRID_API_KEY_HERE";
        private static readonly HttpClient httpClient = new HttpClient();
        public async Task<ActionResult> Index()
        {
            var client = new SendGridClient(httpClient, new SendGridClientOptions { ApiKey = _apiKey, HttpErrorAsException = true });

            var from = new EmailAddress("test@example.com", "Example User");
            var subject = "Hello World from the Twilio SendGrid CSharp Library Helper!";
            var to = new EmailAddress("engtahiralvi@gmail.com", "Tahir Alvi");
            var plainTextContent = "Hello, Email from the helper [SendSingleEmailAsync]!";
            var htmlContent = "<strong>Hello, Email from the helper! [SendSingleEmailAsync]</strong>";

            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            ViewBag.responseCode = response.StatusCode;
            return View();
        }
    }
}