    public bool SendEmail(MailMessage email)
    {
        var client = new SmtpClient();
        
        try
        {
           client.Send(message);
        }
        catch (Exception e)
        {
            return false;
        }
        return true;
    }
    SendMail(createMailMessage("to@email.com", "from@email.com", "Subject", "~/Path/Template"));
