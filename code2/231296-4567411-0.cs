    public class GmailService : IEmailService
    {
        private static int _port = 465;
        private readonly string _accountName;
        private readonly string _password;
    
        public GmailService(string accountName, string password)
        {
            _accountName = accountName;
            _password = password;
        }
        public void Send(string from, string to, string subject, string body, bool isHtml)
        {
            Send(from, to, subject, body, isHtml, null);
        }
    
        public void Send(string from, string to, string subject, string body, bool isHtml, string[] attachments)
        {
            System.Web.Mail.MailMessage mailMessage = new System.Web.Mail.MailMessage
                                                          {
                                                              From = from,
                                                              To = to,
                                                              Subject = subject,
                                                              Body = body,
                                                              BodyFormat = isHtml ? MailFormat.Html : MailFormat.Text
                                                          };
    
    
            // Add attachments
            if (attachments != null)
            {
                for (int i = 0; i < attachments.Length; i++)
                {
                    mailMessage.Attachments.Add(new Attachment(attachments[i]));
                }
            }
    
            //  Authenticate
            mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", 1);
            // Username for gmail - email@domain.com for email for Google Apps
            mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", _accountName);
            // Password for gmail account
            mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", _password);
            // Google says to use 465 or 587.  I don't get an answer on 587 and 465 works - YMMV
            mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", _port.ToString());
            // STARTTLS 
            mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", true);
    
            // assign outgoing gmail server
            SmtpMail.SmtpServer = "smtp.gmail.com";
            SmtpMail.Send(mailMessage);
        }
    }
