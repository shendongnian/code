    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new QuestionViewModel());
        }
        [HttpPost]
        public ActionResult Index(QuestionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("someaccount@gmail.com", "secret");
                var mail = new MailMessage();
                mail.From = new MailAddress("fromaddress@gmail.com");
                mail.To.Add("toaddress@gmail.com");
                mail.Subject = "Test mail";
                mail.Body = model.Question;
                if (model.Attachment != null && model.Attachment.ContentLength > 0)
                {
                    var attachment = new Attachment(model.Attachment.InputStream, model.Attachment.FileName);
                    mail.Attachments.Add(attachment);
                }
                client.Send(mail);
            }
            return Content("email sent", "text/plain");
        }
    }
