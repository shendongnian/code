            try
            {
                for (int recipient = 0; (recipient <= (exObj.InnerExceptions.Length - 1)); recipient++)
                {
                    System.Net.Mail.SmtpStatusCode statusCode;
                    // Each InnerException is an System.Net.Mail.SmtpFailed RecipientException   
                    //for .net 4.0
                    //statusCode = exObj.InnerExceptions(recipient).StatusCode;
                    statusCode = exObj.StatusCode;
                    //if (((statusCode == Net.Mail.SmtpStatusCode.MailboxBusy) || (statusCode == Net.Mail.SmtpStatusCode.MailboxUnavailable)))
                    //for .net 4.0
                    if (((statusCode == System.Net.Mail.SmtpStatusCode.MailboxBusy)
                                || (statusCode == System.Net.Mail.SmtpStatusCode.MailboxUnavailable)))
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
                //MsgBox((exObj.Message + " ==>Procedure SmtpFailedRecipientsException"));
            }
            catch (Exception ex)
            {
                // At this point we have an non recoverable issue:
                // NOTE:  At this point we do not want to re-throw the exception because this method 
                // was called from a 'Catch' block and we do not want a hard error to display to the client.
                // Options: log error, report issue to client via msgbox, etc.   This is up to you.
                // To display issue as you have before:
                // MsgBox((exObj.Message + " ==>Email was not sent"));
            }
        }
