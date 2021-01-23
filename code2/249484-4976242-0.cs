    public bool SendEmail(MailAddress toAddress, string subject, string body)
    {
        MailAddress fromAddress = new MailAddress("pull from db or web.config", "pull from db or web.config");
        string fromPassword = "pull from db or config and decrypt";
        string smtpHost = "pull from db or web.config";
        int smtpPort = 587;//gmail port
    
        try
        {
            var smtp = new SmtpClient
            {
                Host = smtpHost,
                Port = smtpPort,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
            {
                smtp.Send(message);
            }
            return true;
        }
        catch (Exception err)
        {
            Elmah.ErrorSignal.FromCurrentContext().Raise(err);
            return false;
        }
               
    }
