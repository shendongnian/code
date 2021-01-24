    public class XMessage
    {
        private string header;
        private string footer;
        private string xbody;
        
        public MailMessage GetMailMessage()
        {
            return new MailMessage
            {
                 Body = header + xbody + footer
                 // set other properties
            };
        }
    }
