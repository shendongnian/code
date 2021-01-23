    public static void SendMail(string ToMail, string FromMail, string Cc, string Body, string Subject)
    {
        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 25);
        MailMessage mailmsg = new MailMessage();
    
        smtp.EnableSsl = true;
        smtp.Credentials = new NetworkCredential("email","password");
    
        mailmsg.From = new MailAddress(FromMail);
        mailmsg.To.Add(ToMail);
    
        if (Cc != "")
        {
           mailmsg.CC.Add(Cc);
        }
        mailmsg.Body = Body;
        mailmsg.Subject = Subject;
        mailmsg.IsBodyHtml = true;
    
        mailmsg.Priority = MailPriority.High;
                
        try
        {
           smtp.Timeout = 500000;
           smtp.Send(mailmsg);
           mailmsg.Dispose();
        }
        catch (Exception ex)
        {
           throw ex;
        }
    }
