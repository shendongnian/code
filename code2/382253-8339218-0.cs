               SmtpClient mailClient = new SmtpClient();
                //This object stores the authentication values     
                System.Net.NetworkCredential basicCredential =
                    new System.Net.NetworkCredential("username@mydomain.com", "****");
                mailClient.Host = "smtp.gmail.com";
                mailClient.Port = 587;
                mailClient.EnableSsl = true;
                mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                mailClient.UseDefaultCredentials = false;
                mailClient.Credentials = basicCredential;
                MailMessage message = new MailMessage();
                MailAddress fromAddress = new MailAddress("info@mydomain.com", "Me myself and I ");
                message.From = fromAddress;
                //here you can set address   
                message.To.Add("to@you.com");
                //here you can put your message details
                mailClient.Send(message);
