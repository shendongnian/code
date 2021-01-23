    using (var message = new MailMessage("me@contoso.com", "you@contoso.com", "Just testing", "See attachment..."))
    {
      var stream = new MemoryStream();
      var writer = new StreamWriter(stream);    // using UTF-8 encoding by default
    
      writer.WriteLine("Comma,Seperated,Values,...");
      writer.Flush();
      stream.Position = 0;     // read from the start of what was written
    
      message.Attachments.Add(new Attachment(stream, "filename.csv", "text/csv"));
            
      var mailClient = new SmtpClient();
      mailClient.Send(message);
    }
