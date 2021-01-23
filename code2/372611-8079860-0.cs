    SmtpClient client = ...
    
    client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
    
    using (MailMessage message = ...)
    {
      // where userToken is a user-defined token
      // to be passed to the SendCompletedCallback
      client.SendAsync(message, userToken);
    } // Disposes of message
