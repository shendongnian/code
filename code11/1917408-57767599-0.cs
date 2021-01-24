     MailAddress fromAddress = new MailAddress("aaa@interia.pl", "Tom S");
            MailAddress toAddress = new MailAddress("bbb@interia.pl", "John B");
            const string fromPassword = "my_pass";
            string body = "new message";
            using (SmtpClient smtp = new SmtpClient
            {
                Host = "poczta.interia.pl",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            })
            {
                using (MailMessage message = new MailMessage(fromAddress, toAddress))
                {
                    message.Subject = Environment.MachineName;
                    message.Body = body;
                    using (var fileStream = File.OpenRead(@"E:\ExcellOld.xls"))
                    {
                        System.Net.Mime.ContentType ct = new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Text.Plain);
                        System.Net.Mail.Attachment attach = new System.Net.Mail.Attachment(fileStream, ct);
                        message.Attachments.Add(attach);
                        smtp.Send(message);
                    }
                }
            }
