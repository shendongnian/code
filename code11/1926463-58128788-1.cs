    void SendMailWithXOAUTH2(string userEmail, string accessToken)
    {
        try
        {
            // Gmail SMTP server address
            SmtpServer oServer = new SmtpServer("smtp.gmail.com");
            // enable SSL connection
            oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;
            // Using 587 port, you can also use 465 port
            oServer.Port = 587;
    
            // use Gmail SMTP OAUTH 2.0 authentication
            oServer.AuthType = SmtpAuthType.XOAUTH2;
            // set user authentication
            oServer.User = userEmail;
            // use access token as password
            oServer.Password = accessToken;
    
            SmtpMail oMail = new SmtpMail("TryIt");
            // Your gmail email address
            oMail.From = userEmail;
            oMail.To = "support@emailarchitect.net";
    
            oMail.Subject = "test email from gmail account with OAUTH 2";
            oMail.TextBody = "this is a test email sent from c# project with gmail.";
    
            Console.WriteLine("start to send email using OAUTH 2.0 ...");
    
            SmtpClient oSmtp = new SmtpClient();
            oSmtp.SendMail(oServer, oMail);
    
            Console.WriteLine("The email has been submitted to server successfully!");
        }
        catch (Exception ep)
        {
            Console.WriteLine("Exception: {0}", ep.Message);
        }
