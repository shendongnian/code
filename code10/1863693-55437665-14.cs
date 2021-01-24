    using (var stream = new MemoryStream())
       using (var writer = new StreamWriter(stream)) // using UTF-8 encoding by default
          using (var mailClient = new SmtpClient("localhost", 25))
             using (var message = new MailMessage("me@example.com", "you@example.com", "Just testing", "See attachment..."))
             {
                writer.WriteLine("file content blah blah blahh");
                writer.Flush();
                stream.Position = 0; // read from the start of what was written
    
                message.Attachments.Add(new Attachment(stream, "filename.csv", "text/csv"));
    
                mailClient.Send(message);
             }
