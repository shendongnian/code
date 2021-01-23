    using System;
    using System.Net.Mail;
    
    public static class MailHandler
    {
        public static void SendMail(string sender, string recipient)
        {
            SendMail(sender, new string[] { recipient });
        }
        public static void SendMail(string sender, string[] recipients)
        {
            var client = new SmtpClient("127.0.0.1", 25);
    
            foreach (string recipient in recipients)
            {
                var message = new MailMessage(sender, recipient);
                message.IsBodyHtml = true;
                message.Subject = "Hello World!";
                message.Body = "<h1>Hello World</h1> (<i>via mail</i>)";
                client.Send(message);
            }
        }
    }
