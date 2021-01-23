            try
            {
                var fromAddress = new MailAddress("address@gmail.com", "Support");
                var toAddress = new MailAddress(user.email, user.username);
                const string subject = "Processing";
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("username", "password")
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = dataToSend
                })
                {
                    message.IsBodyHtml = true;
                    smtp.Send(message);
                }
            }
            catch (Exception)
            {
                Model.Message = "Exception Occured During Mail Sending";
            }
