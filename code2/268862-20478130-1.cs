    public class MailMessage : MvcMailMessage, IMailMessage
    {
    
    }
    public class UserMailer : MailerBase, IUserMailer
    {
        public UserMailer()
        {
            MasterName = "_Layout";
        }
        public IMailMessage Welcome(WelcomeMailModel model)
        {
            var mailMessage = new MailMessage();
            mailMessage.SetRecipients(model.To);
            mailMessage.Subject = "Welcome";
            ViewData = new System.Web.Mvc.ViewDataDictionary(model);
            PopulateBody(mailMessage, "Welcome");
            return mailMessage;
        }
    }
