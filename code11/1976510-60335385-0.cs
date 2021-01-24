    var memStream = new MemoryStream();
    var mimeMessage = MimeMessage.CreateFromMailMessage(encryptedMailMessage);
    mimeMessage.WriteTo(memStream);
    var messageString = Encoding.UTF8.GetString(memoryStream.ToArray());
    byte[] encryptedBodyBytes = Encoding.ASCII.GetBytes(messageString);
