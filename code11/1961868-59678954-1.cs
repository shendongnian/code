    public class HomeController : Controller
    {
        private readonly EmailSettingsModel emailSender;
        public HomeController(EmailSettingsModel _emailSender)
        {
            emailSender = _emailSender;
        }
        public IActionResult Index()
        {
            var a = emailSender.MailServer ;
            return View();
        }
    }
