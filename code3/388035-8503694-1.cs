    protected void Page_Load(object sender, EventArgs e)
    {
        MailMessage mailMessage = new System.Net.Mail.MailMessage();
        mailMessage.To.Add("real@address.com");
        mailMessage.Subject = "Some subject";
        mailMessage.Body = "Some text";
    
        using (var smtpClient = new SmtpClient())
        {
            smtpClient.Send(mailMessage);
        }
    }
