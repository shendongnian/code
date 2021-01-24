      private static void Send(string toEmailAddress, string subject, string message)
            {
                   var mail = new MailMessage
                {
                    IsBodyHtml = true,
                    From = new MailAddress("email@gmail.com"),
                    Body = message,
                    Subject = subject,
                    To = {new MailAddress(toEmailAddress)}
                };
    
                
                var smtpServer = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("email@gmail.com", "Password123"),
                    EnableSsl = true
                };
    
             
                smtpServer.Send(mail);
            }
