        void SendEmail(EmailEnity email)
        {
            var mailMessage = new MailMessage { From = new MailAddress(email.From) };
            mailMessage.To.Add(new MailAddress(email.To));
            mailMessage.Subject = email.Subject;
            mailMessage.Body = email.Body;
            mailMessage.IsBodyHtml = true;
            // Send the email
            var client = new SmtpClient();
            client.Send(mailMessage);
        }
