    public class EmailManager : IEmailManager
    {
        private readonly EmailConfiguration _emailSettings;
        public EmailManager(EmailConfiguration emailConfiguration)
        {
            _emailSettings = emailConfiguration;
        }
        public bool SendEmail<T>(string subject, string body, string fromAddress, List<string> toAddresses, List<string> ccAddresses, List<string> bccAddresses, string name = "", List<string> filePaths = null, string htmlFile = "", T data = default(T), bool apptUpdate = false)
        {
               string host = _emailSettings.Host;
               SmtpClient smtpClient = new SmtpClient(_emailSettings.Host, _emailSettings.Port);
               smtpClient.EnableSsl = true;
               smtpClient.UseDefaultCredentials = false;
               MailAddress from = new MailAddress(_emailSettings.MailAddress, _emailSettings.MailDisplayName);
               smtpClient.Credentials = new NetworkCredential(_emailSettings.Username, _emailSettings.Password);
               MailMessage myMail = new MailMessage();
               myMail.From = from;
              //Rest logic to send email
        }    
    }
