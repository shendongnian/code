    public void SendMail(string tomail, string password)
    {
        {
            try
            {
                SmtpClient mailClient = new SmtpClient();
                MailMessage mailMessage = new MailMessage();               
                mailMessage.To.Add(tomail);
                mailMessage.From = new MailAddress("email", "show name");
                mailMessage.Subject = "Your password";
                mailMessage.Body = "Your password is :" + password;
                mailMessage.IsBodyHtml = true;
                mailMessage.Priority = MailPriority.Normal;
                mailClient.Host = "Smtp.gmail.com";
                mailClient.Port = 587;
                mailClient.UseDefaultCredentials = false;
                mailClient.Credentials = new NetworkCredential("ur email id", "ur password");
                mailClient.EnableSsl = true;
                mailClient.Send(mailMessage);
               lblPassword.Text = "<b>Mail Successfully Sent..!!</b>";
            }
            catch (Exception ex)
            {
                ex.ToString();
               lblPassword.Text = "<b>Error For Sending Mail..!!</b>";
            }
        }
    }
