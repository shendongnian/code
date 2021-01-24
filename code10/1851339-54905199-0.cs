     private void SendMailMessage(string From, string SendTo, string Subject, string Body, bool IsBodyHtml, string Server) 
            {
    
                MailMessage htmlMessage;
                SmtpClient mySmtpClient;
    
                htmlMessage = new MailMessage(From, SendTo, Subject, Body);  
                htmlMessage.IsBodyHtml = IsBodyHtml;
                foreach (var address in SendTo.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries))
                {
                    htmlMessage.To.Add(address);
                }
    
                mySmtpClient = new SmtpClient(Server);
                mySmtpClient.Send(htmlMessage);
    
            } 
