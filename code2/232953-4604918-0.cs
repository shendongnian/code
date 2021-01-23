    ...
    
    byte[] data = ASCIIEncoding.Default.GetBytes(ieLog.FirstName + "." + ieLog.LastName);
    
    using(MemoryStream ms = new MemoryStream(data))
    {
        mail.Attachments.Add(new Attachment(ms, "myFile.csv", "text/csv" ));
    
        SmtpClient smtp = new SmtpClient("127.0.0.1");
        smtp.Send(mail);   
    }
