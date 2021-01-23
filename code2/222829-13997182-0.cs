        /// <summary>
    /// Overrides the default SMTP Client class to go ahead and default the host and port to Mandrills goodies.
    /// </summary>
    public class MandrillSmtpClient : SmtpClient
    {
        public MandrillSmtpClient( string smtpUsername, string apiKey, string host = "smtp.mandrillapp.com", int port = 587 )
            : base( host, port )
        {
            
            this.Credentials = new NetworkCredential( smtpUsername, apiKey );
            this.EnableSsl = true;
        }
    }
