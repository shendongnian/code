    /// <summary>
    /// A Generic Method to send email using Gmail
    /// </summary>
    /// <param name="to">The To address to send the email to</param>
    /// <param name="subject">The Subject of email</param>
    /// <param name="body">The Body of email</param>
    /// <param name="isBodyHtml">Tell whether body of email will be html of plain text</param>
    /// <param name="mailPriority">Set the mail priority to low, medium or high</param>
    /// <returns>Returns true if email is sent successfuly</returns>
    public static Boolean SendMail(String to, String subject, String body, Boolean isBodyHtml, MailPriority mailPriority)
    {
        try
        {
            // Configure mail client (may need additional
            // code for authenticated SMTP servers)
            SmtpClient mailClient = new SmtpClient("smtp.gmail.com", 587);
    
            // set the network credentials
            mailClient.Credentials = new NetworkCredential("YourGmailEmail@gmail.com", "YourGmailPassword");
    
            //enable ssl
            mailClient.EnableSsl = true;
    
            // Create the mail message (from, to, subject, body)
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("YourGmailEmail@gmail.com");
            mailMessage.To.Add(to);
    
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = isBodyHtml;
            mailMessage.Priority = mailPriority;
    
            // send the mail
            mailClient.Send(mailMessage);
    
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
