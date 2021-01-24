    using (SmtpClient client = new SmtpClient())
    using (MailMessage message = new MailMessage())
    {
        client.Host = "host.com";
        client.Port = 25;
        client.Timeout = 10000;
        client.EnableSsl = false;
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        client.Credentials = new NetworkCredential("user", "pass");
    
        message.From = new MailAddress("email@from.nl", "VDWWD");
        message.To.Add(new MailAddress("email@to.nl"));
        message.Subject = "Your uploaded files";
        message.IsBodyHtml = true;
        message.Body = "<html><head></head><body><font face=\"arial\" size=\"2\"><b>The files you uploaded.</b></font></body></html>";
    
        //loop all the uploaded files
        foreach (var file in FileUpload1.PostedFiles)
        {
            //add the file from the fileupload as an attachment
            message.Attachments.Add(new Attachment(file.InputStream, file.FileName, MediaTypeNames.Application.Octet));
        }
    
        //send mail
        try
        {
            client.Send(message);
        }
        catch (Exception ex)
        {
            //handle error
        }
    }
