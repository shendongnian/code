    private void sendMail()
    {
        List<MailAddress> lst = new List<MailAddress>();
    
        lst.Add(new MailAddress("mouse@xxxx.com"));
        lst.Add(new MailAddress("duck@xxxx.com"));
        lst.Add(new MailAddress("goose@xxxx.com"));
        lst.Add(new MailAddress("wolf@xxxx.com"));
    
    
        try
        {
    
    
            MailMessage objeto_mail = new MailMessage();
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.Host = "10.15.130.28"; //or SMTP name
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("from@email.com", "password");
            objeto_mail.From = new MailAddress("from@email.com");
    
            foreach (MailAddress m in lst)
            {
                objeto_mail.To.Add(m);
            }
    
    
            objeto_mail.Subject = "Sending mail test";
            objeto_mail.Body = "Functional test for automatic mail :-)";
            client.Send(objeto_mail);
    
    
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
