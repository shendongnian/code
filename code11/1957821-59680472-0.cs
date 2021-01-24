    private void emailgrid(object sender, RoutedEventArgs e)
    {
        try
        {
            MailMessage mail = new MailMessage();
            //put your SMTP address and port here.
            SmtpClient SmtpServer = new SmtpClient("");
            //Put the email address
            mail.From = new MailAddress("email@gmail.com");
            //Put the email where you want to send.
            mail.To.Add("email@gmail.com");
    
            mail.Subject = "suubject";
    
            StringBuilder sbBody = new StringBuilder();
    
            sbBody.AppendLine("body");
    
            mail.Body = sbBody.ToString();
    
            //Your log file path
            System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(@"C:\XML\see.xml");
    
            mail.Attachments.Add(attachment);
    
            //Your username and password!
            SmtpServer.Credentials = new System.Net.NetworkCredential("UserName", "Password");
            //Set Smtp Server port
            SmtpServer.Port = 25;
            //SmtpServer.EnableSsl = true;
    
            SmtpServer.Send(mail);
            MessageBox.Show("Hello User Your Mail Has Been Sent");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    
    }        
