        SmtpClient smtpClient = new SmtpClient();
        MailMessage message = new MailMessage();
        try
        {
           // System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            MailAddress fromAddress = new MailAddress(txt_name.Text, txt_to.Text);
            
            smtpClient.Host = "smtp.gmail.com";
           
            smtpClient.Port = 25;
           // msg.From = new System.Net.Mail.MailAddress("xyz@gmail.com");
          message.From = fromAddress;
            message.To.Add("xyz111@gmail.com");
           
            message.Body = txt_des.Text;
            smtpClient.EnableSsl = true;
            System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
            NetworkCred.UserName = "xyz@gmail.com";
            NetworkCred.Password = "xtz";
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Credentials = NetworkCred; 
         
            smtpClient.Send(message);
            lblStatus.Text = "Email successfully sent.";
        }
        catch (Exception ex)
        {
            lblStatus.Text = "Send Email Failed." + ex.Message;
        }
