            public static void Send(string replyTo, string from, string subject, string body, bool html, List<string> files)
        {
                MailMessage message = new MailMessage();
                message.To.Add(replyTo);
                message.Subject = subject;
                message.From = new MailAddress(from);
                message.Body = body;
                message.IsBodyHtml = html;
                if (files != null) message = AttachFiles(files, message);
                SmtpClient sMail = new SmtpClient("smtp.client.com");
                sMail.Port = 25;
                sMail.DeliveryMethod = SmtpDeliveryMethod.Network;
                sMail.Credentials = new NetworkCredential("user", "pass");
                sMail.Send(message);
        }
        public static MailMessage AttachFiles(List<string> files, MailMessage message)
        {
            foreach (string filePath in files)
            {
                message.Attachments.Add(new Attachment(filePath));
            }
            return message;
        }
