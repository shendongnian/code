    using System.IO;
    using System.Net.Mail;
    using System.Text;
    using System.Net;
    public sealed class Emailer
    {
        private Emailer()
        {
        }
    
        public static void SendMail(string subject, string to, 
            string from = null, string body = null, Stream attachment = null,
            int port = 25, string host = "localhost", bool isBodyHtml = true)
        {
            MailMessage mailMsg = new MailMessage();
            mailMsg.From = new MailAddress(from);
            mailMsg.To.Add(to);
            mailMsg.Subject = subject;
            mailMsg.IsBodyHtml = isBodyHtml;
            mailMsg.BodyEncoding = Encoding.UTF8;
            mailMsg.Body = body;
            mailMsg.Priority = MailPriority.Normal;
    
            //Message attahment
            if (attachment != null)
                mailMsg.Attachments.Add(new Attachment(attachment, "my.text"));
    
            // Smtp configuration
            SmtpClient client = new SmtpClient();
            client.Credentials = new NetworkCredential("YOUR_GMAIL_USER_NAME", "PASSWORD");
            client.UseDefaultCredentials = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Port = port; //use 465 or 587 for gmail           
            client.Host = host;//for gmail "smtp.gmail.com";
            client.EnableSsl = false;
    
            MailMessage message = mailMsg;
            
            client.Send(message);
            
        }
    
    }
