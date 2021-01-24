    public class SendMailJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            return Task.Factory.StartNew(() => SendEmail());
        }
        public void SendMail()
        {
            MailMessage Msg = new MailMessage();
    
            Msg.From = new MailAddress("mymail@mail.com", "Me");
    
            Msg.To.Add(new MailAddress("receivermail@mail.com", "ABC"));
    
            Msg.Subject = "Inviare Mail con C#";
    
            Msg.Body = "Mail Sended successfuly";
            Msg.IsBodyHtml = true;
    
            SmtpClient Smtp = new SmtpClient("smtp.live.com", 25);
    
            Smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
    
            Smtp.UseDefaultCredentials = false;
            NetworkCredential Credential = new
            NetworkCredential("mymail@mail.com", "password");
            Smtp.Credentials = Credential;
    
            Smtp.EnableSsl = true;
    
            Smtp.Send(Msg);
        }
    }
