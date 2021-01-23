            btnSend.Disabled = true;
            const string serverHost = "relay-hosting.secureserver.net";
            var msg = new MailMessage(toAddress, toAddress);
            msg.ReplyTo = new MailAddress(emailFrom);
            
            msg.Subject = subject;
            msg.Body = emailBody;
            msg.IsBodyHtml = false;
            try
            {
                var smtp = new SmtpClient();
                smtp.Host = serverHost;
                smtp.Credentials = new System.Net.NetworkCredential("mail", "4ngelit0");
                smtp.Send(msg);
            }
            catch (Exception e)
            {
                //Log the errors so that we can see them somewhere
            }
