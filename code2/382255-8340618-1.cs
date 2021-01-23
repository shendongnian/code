    Public void SendEmail(string toEmailAddress, string mailBody)
            {
                try
                {
                    MailMessage mailMessage = new System.Net.Mail.MailMessage();
                    mailMessage.To.Add(toEmailAddress);
                    mailMessage.Subject = "Mail Subjectxxxx";
                    mailMessage.Body = mailBody;
                    var smtpClient = new SmtpClient();
                    smtpClient.Send(mailMessage);
                    return "Mail send successfully";
                }
                catch (SmtpException ex)
                {
                    return "Mail send failed:" + ex.Message;
                }
