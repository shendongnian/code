    MailMessage Message = new MailMessage();
    
    Message.Sender = new MailAddress(OutgoingEmailAddress, OutgoingEmailDisplayName);
    Message.From = new MailAddress(OutgoingEmailAddress, OutgoingEmailDisplayName);
    Message.Subject = "The subject of your email";
    Message.Priority = MailPriority.High;
    
    // Add Recipients                    
    foreach (string Email in (SuccessRecipientList.Split(';')))
         Message.To.Add(Email);
    
    // Set Body                
    Message.Body = Body;
    
    // Send the Email
    SmtpClient EmailClient = new SmtpClient("smtpServerNameHere");
    EmailClient.Send(Message);
