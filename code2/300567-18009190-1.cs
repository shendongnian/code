        MailMessage msg = new MailMessage();
        msg.To.Add(new MailAddress("someone@somedomain.com", "SomeOne"));
        msg.From = new MailAddress("you@yourdomain.com", "You");
        msg.Subject = "This is a Test Mail";
        msg.Body = "This is a test message using Exchange OnLine";
        msg.IsBodyHtml = true;
        SmtpClient client = new SmtpClient();
        client.UseDefaultCredentials = false;
        client.Credentials = new System.Net.NetworkCredential("your user name", "your password");
        client.Port = 587; // You can use Port 25 if 587 is blocked (mine is!)
        client.Host = "smtp.office365.com";
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.EnableSsl = true;
        try
        {
            client.Send(msg);
            lblText.Text = "Message Sent Succesfully";
        }
        catch (Exception ex)
        {
            lblText.Text = ex.ToString();
        }
