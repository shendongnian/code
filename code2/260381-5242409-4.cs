    try
    {
        objSMTPClient.Timeout = TimeoutValue;
        objSMTPClient.Send(objMailMsg);
        //objSMTPClient.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
        objMailMsg.Dispose();
    }
    catch (SmtpException smtpEx)
    {
        if (smtpEx.Message.Contains("secure connection"))
        {
            objSMTPClient.EnableSsl = true;
            objSMTPClient.Send(objMailMsg);
        }
    }
