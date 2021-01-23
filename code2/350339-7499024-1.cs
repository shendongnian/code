    using System;
    using System.Net.Mail;
        
    public class Test
    {
        public static void Main()
        {
            SmtpClient client = new SmtpClient("smtphost", 25);
            MailMessage msg = new MailMessage("x@y.com", "a@b.com,c@d.com");
            msg.Subject = "sdfdsf";
            msg.Body = "sdfsdfdsfd";
            client.UseDefaultCredentials = true;
            client.Send(msg);
        }
    }
