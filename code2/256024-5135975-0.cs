    namespace SendAttachmentMail
    {
        class Program
        {
            static void Main(string[] args)
            {
                var myAddress = new MailAddress("jhered@yahoo.com","James Peckham");
                MailMessage message = new MailMessage(myAddress, myAddress);
                message.Body = "Hello";
                message.Attachments.Add(new Attachment(@"Test.txt"));
                var client = new YahooMailClient();
                client.Send(message);
            }
        }
        public class YahooMailClient : SmtpClient
        {
            public YahooMailClient()
                : base("smtp.mail.yahoo.com", 25)
            {
                Credentials = new YahooCredentials();
            }
        }
        public class YahooCredentials : ICredentialsByHost
        {
            public NetworkCredential GetCredential(string host, int port, string authenticationType)
            {
                return new NetworkCredential("jhered@yahoo.com", "mypwd");
            }
        }
    }
