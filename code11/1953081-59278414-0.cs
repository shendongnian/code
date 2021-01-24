    private void Send_Clicked(object sender, EventArgs e)
        {
            try
            {
                .......
            }
            catch(Exception ex)
            {
                Email(ex.ToString());
            }
           
        }
        public static void Email(string htmlString)
        {
            MailMessage msg = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            msg.From = new MailAddress("email here");
            msg.To.Add(new MailAddress("other email here"));
            msg.Subject = "Error Report";
            msg.IsBodyHtml = true;
            msg.Body = htmlString;
            smtp.Port = 1234;
            smtp.Host = "smtp here";
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("email", "password");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(msg);        
        }
