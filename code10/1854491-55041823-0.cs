      private void Send()
    {
        using (SmtpClient client = new System.Net.Mail.SmtpClient("server", 25)) // 25 - port number
        {
            // Configure the client
      
       
     client.UseDefaultCredentials = true;
                           
            MailMessage message = new MailMessage(
                                     "email from", // From field
                                     "Recipient", // Recipient field
                                     "Hello", // Subject of the email message
                                     "message"// Email message body
                                  );
            client.Send(message);
        }
    }
