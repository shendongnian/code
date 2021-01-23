            MailMessage message = new MailMessage("myemail@gmail.com", toemail, subjectEmail, comments);
            message.IsBodyHtml = true;
            try {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.Timeout = 2000;
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                //client.Credentials = CredentialCache.DefaultNetworkCredentials;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("myemail@gmail.com", "mypassord");
                client.Send(message);
                message.Dispose();
                client.Dispose();
            }
            catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
