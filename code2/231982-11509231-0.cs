                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("mail.yourhost.com",155);//add custom port here
                //This object stores the authentication values
                System.Net.NetworkCredential mycredentials = new System.Net.NetworkCredential("yourname@yourdomain.com", "passwordhere");
                client.UseDefaultCredentials = false;
                client.Credentials = mycredentials;
