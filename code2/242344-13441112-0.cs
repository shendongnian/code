    try { _emailMsg.Body = _MessageBody; _emailMsg.Priority = MailPriority.Normal;
    
    SmtpClient mSmtpClient = new SmtpClient(server,25);
    
    mSmtpClient.Send(_emailMsg); return true; } catch (Exception ex) { throw new Exception("Error Sending Email: " + ex.Message);
    
    return false; }
