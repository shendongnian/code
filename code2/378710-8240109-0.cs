     // Change your Try-Catch to call the new method named 'CheckExceptionAndResend'
    // Error handling for sending message   
    try 
    {
        smtpClient.Send(message);
        // Exception contains information on each failed receipient   
    }
    catch (System.Net.Mail.SmtpFailedRecipientsException recExc)
    {
        // Call method that will analyze exception and attempt to re-send the email
        CheckExceptionAndResend(recExc, smtpClient, message);
    }
    catch (System.Net.Mail.SmtpException smtpExc)
    {
        // Log error to event log using StatusCode information in   
        // smtpExc.StatusCode   
        MsgBox((smtpExc.StatusCode.ToString + " ==>Procedure SmtpException"));
    }
    catch (Exception Exc) 
    {
        // Log error to event log using StatusCode information in   
        // smtpExc.StatusCode   
        MsgBox((Exc.Message + " ==>Procedure Exception"));
    }
    
    private void CheckExceptionAndResend(System.Net.Mail.SmtpFailedRecipientsException exObj, System.Net.Mail.SmtpClient smtpClient, MailMessage emailMessage)
    {
        try
        {
            for (int recipient = 0; (recipient <= (exObj.InnerExceptions.Length - 1)); recipient++)
            {
                System.Net.Mail.SmtpStatusCode statusCode;
                // Each InnerException is an System.Net.Mail.SmtpFailed RecipientException   
                statusCode = exObj.InnerExceptions(recipient).StatusCode;
                if (((statusCode == Net.Mail.SmtpStatusCode.MailboxBusy) 
                            || (statusCode == Net.Mail.SmtpStatusCode.MailboxUnavailable))) 
                {
                    // Log this to event log: recExc.InnerExceptions(recipient).FailedRecipient   
                    System.Threading.Thread.Sleep(5000);
                    smtpClient.Send(emailMessage);
                }
                else
                {
                    // Log error to event log.   
                    // recExc.InnerExceptions(recipient).StatusCode or use statusCode   
                }
            }
            MsgBox((exObj.Message + " ==>Procedure SmtpFailedRecipientsException"));
        }
        catch (Exception ex) 
        {
            // At this point we have an non recoverable issue:
            // NOTE:  At this point we do not want to re-throw the exception because this method 
            // was called from a 'Catch' block and we do not want a hard error to display to the client.
            // Options: log error, report issue to client via msgbox, etc.   This is up to you.
            // To display issue as you have before:
            MsgBox((exObj.Message + " ==>Email was not sent"));
        }
    }
