                //1.The ACCOUNT
                MailAddress fromAddress = new MailAddress("myaccount@myaccount.com", "my display name");                
		        String fromPassword = "password";
                //2.The Destination email Addresses
                MailAddressCollection TO_addressList = new MailAddressCollection();
                //3.Prepare the Destination email Addresses list
                foreach (var curr_address in mailto.Split(new [] {";"}, StringSplitOptions.RemoveEmptyEntries))
                {
                    MailAddress mytoAddress = new MailAddress(curr_address, "Custom display name");
                    TO_addressList.Add(mytoAddress);
                }
                //4.The Email Body Message
                String body = bodymsg;
                
                //5.Prepare GMAIL SMTP: with SSL on port 587
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                    Timeout = 30000
                };
                
                //6.Complete the message and SEND the email:
                using (var message = new MailMessage()
                {
                    From = fromAddress,                    
                    Subject = subject,
                    Body = body,                      
                })
                {
                    message.To.Add(TO_addressList.ToString());
                    smtp.Send(message);
                }
