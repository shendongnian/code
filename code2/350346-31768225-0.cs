        private string from;
        private string to;
        private string subject;
        private string body;
        private SmtpClient smtpClient;
        private MailMessage mailMessage;
        private MailPriority mailPriority;
        private MailAddressCollection mailAddressCollection;
        private MailAddress fromMailAddress, toMailAddress;
        public MailAddressCollection toMailAddressCollection
        { get; set; }
        public MailAddressCollection ccMailAddressCollection
        { get; set; }
        public MailAddressCollection bccMailAddressCollection
        { get; set; }
        public ObserverLogToEmail(string from, string to, string subject, string body, SmtpClient smtpClient)
		{
            this.from = from;
            this.to = to;
            this.subject = subject;
            this.body = body;
            
            this.smtpClient = smtpClient;
		}
        public ObserverLogToEmail(MailAddress fromMailAddress, MailAddress toMailAddress, 
                                  string subject, string content, SmtpClient smtpClient)
        {
            try
            {
                this.fromMailAddress = fromMailAddress;
                this.toMailAddress = toMailAddress;
                this.subject = subject;
                this.body = content;
                this.smtpClient = smtpClient;
                mailAddressCollection = new MailAddressCollection();
                
            }
            catch
            {
                throw new SmtpException(SmtpStatusCode.CommandNotImplemented);
            }
        }
        public ObserverLogToEmail(MailAddressCollection fromMailAddressCollection, 
                                  MailAddressCollection toMailAddressCollection, 
                                  string subject, string content, SmtpClient smtpClient)
        {
            try
            {
                this.toMailAddressCollection = toMailAddressCollection;
                this.ccMailAddressCollection = ccMailAddressCollection;
                this.subject = subject;
                this.body = content;
                this.smtpClient = smtpClient;
            }
            catch
            {
                throw new SmtpException(SmtpStatusCode.CommandNotImplemented);
            }
        }
        public ObserverLogToEmail(MailAddressCollection toMailAddressCollection,
                                  MailAddressCollection ccMailAddressCollection,
                                  MailAddressCollection bccMailAddressCollection,
                                  string subject, string content, SmtpClient smtpClient)
        {
            try
            {
                this.toMailAddressCollection = toMailAddressCollection;
                this.ccMailAddressCollection = ccMailAddressCollection;
                this.bccMailAddressCollection = bccMailAddressCollection;
                this.subject = subject;
                this.body = content;
                this.smtpClient = smtpClient;
            }
            catch
            {
                throw new SmtpException(SmtpStatusCode.CommandNotImplemented);
            }
        }
        #region ILog Members
        
        // sends a log request via email.
        // actual email 'Send' calls are commented out.
        // uncomment if you have the proper email privileges.
        public void Log(object sender, LogEventArgs e)
        {
            string message = "[" + e.Date.ToString() + "] " + e.SeverityString + ": " + e.Message;
            fromMailAddress = new MailAddress("","HaNN",System.Text.Encoding.UTF8);
            toMailAddress = new MailAddress("","XXX",System.Text.Encoding.UTF8);
            
            mailMessage = new MailMessage(fromMailAddress,toMailAddress);
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            
            // commented out for now. you need privileges to send email.
            // _smtpClient.Send(from, to, subject, body);
            smtpClient.Send(mailMessage);
        }
        public void LogAllEmails(object sender, LogEventArgs e)
        {
            try
            {
                 string message = "[" + e.Date.ToString() + "] " +  e.SeverityString + ": " + e.Message;
                 mailMessage = new MailMessage();
                 mailMessage.Subject = subject;
                 mailMessage.Body = body;
                 
                 foreach(MailAddress toMailAddress in toMailAddressCollection)
                 {
                     mailMessage.To.Add(toMailAddress);
                     
                 }
                 foreach(MailAddress ccMailAddress in ccMailAddressCollection)
                 {
                     mailMessage.CC.Add(ccMailAddress);
                 }
                 foreach(MailAddress bccMailAddress in bccMailAddressCollection)
                 {
                     mailMessage.Bcc.Add(bccMailAddress);
                 }
                if(smtpClient == null)
                {
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential("yourEmailAddress", "yourPassword"),
                        Timeout = 30000
                    };
                }
                else
                 smtpClient.SendAsync(mailMessage, null);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        }
}
