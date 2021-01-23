            try
            {
                MailMessage msg = new MailMessage();
                msg.To.Add(input.To);
                msg.From = new MailAddress(input.From);
                msg.Subject = input.Subject;
                msg.Body = input.Message;
                Attachment att = new Attachment(reportPath);
                msg.Attachments.Add(att);
                SmtpClient client = new SmtpClient(serverAddress, serverPort);
                client.Credentials = creds;
                client.EnableSsl = true;
                client.Send(msg);
                msg.Dispose();
            }
