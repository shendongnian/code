     MailMessage message = new MailMessage(from, to, subject, body);
                message.IsBodyHtml = true;
                message.Priority = MailPriority.High;
                SmtpClient mailClient = new SmtpClient();
                mailClient.EnableSsl = true;
                mailClient.Send(message);
                message.Dispose();
