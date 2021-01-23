          /// <summary>
          ///Method to Send an Email informing interested parties about the status of data extraction. 
          /// INPUTS : int iProcessIsSuccess : int informing about the success of the process. -1 means failure, 0 means partial success, 1 means success. 
          ///          string szLogDataToBeSent :  Log data to be sent incase process not successful.
          /// OUTPUTS : bool. True if success, else false.
          /// </summary>
          public bool SendEmailNotification(string szEmailAddressFileName, int iProcessIsSuccess, string szLogDataToBeSent)
          {
             bool bSuccess = false;
    
             //the the SMTP host.
             SmtpClient client = new SmtpClient();
    
             //SMTP Server
             client.Host = CommonVariables.EMAIL_SMTP_SERVER;
    
             //SMTP Credentials
             client.Credentials = new NetworkCredential(CommonVariables.EMAIL_USERNAME, CommonVariables.EMAIL_PASSWORD);
    
             //Creating a new mail.
             MailMessage mail = new MailMessage();
    
             //Filling 'From' Tab.
             mail.From = new MailAddress(CommonVariables.EMAIL_SENDERS_ADDRESS, CommonVariables.EMAIL_SENDERS_NAME);
             
             //Filling 'To' tab.
             List<EmailAddress> EmailAddressList = new List<EmailAddress>();
             try
             {
                using (System.IO.FileStream fs = new FileStream(szEmailAddressFileName, FileMode.Open))
                {
                   XmlSerializer xs = new XmlSerializer(typeof(List<EmailAddress>));
                    EmailAddressList = xs.Deserialize(fs) as List<EmailAddress>;
                }
    
                foreach (EmailAddress addr in EmailAddressList)
                {
                   mail.To.Add(addr.RecepientEmailAddress);
                }
             }
             catch(Exception Ex)
             {
                mail.To.Add("DefautEmailId@company.com");
             }
    
             //Filling mail body.
             string szMailBody = "";
             string szMailSubject = "";
    
             if (1 == iProcessIsSuccess) //Success
             {
                szMailSubject = String.Format(CommonVariables.EMAIL_SUBJECT_BOILER_PLATE, "a SUCCESS");
                szMailBody = String.Format(CommonVariables.EMAIL_BODY_BOILER_PLATE, DateTime.UtcNow.ToString(), Environment.MachineName);
                szMailBody += "\r\n" + szMailSubject + "\r\n";
    
             }
             else if (0 == iProcessIsSuccess) //Partially Success
             {
                szMailSubject = String.Format(CommonVariables.EMAIL_SUBJECT_BOILER_PLATE, "a PARTIAL SUCCESS"); ;
                szMailBody = String.Format(CommonVariables.EMAIL_BODY_BOILER_PLATE, DateTime.UtcNow.ToString(), Environment.MachineName);
                szMailBody += "\r\n"+ szMailSubject + "\r\n";
                szMailBody += "\r\n" + "The Log data is as follows:\r\n";
                szMailBody += szLogDataToBeSent;
                mail.Priority = MailPriority.High;
             }
             else //Failed
             {
                szMailSubject = String.Format(CommonVariables.EMAIL_SUBJECT_BOILER_PLATE, "a FAILURE"); ;
                szMailBody = String.Format(CommonVariables.EMAIL_BODY_BOILER_PLATE, DateTime.UtcNow.ToString(), Environment.MachineName);
                szMailBody += "\r\n" + szMailSubject + "\r\n";
                szMailBody += "\r\n" + "The Log data is as follows:\r\n";
                szMailBody += szLogDataToBeSent;
                mail.Priority = MailPriority.High;
             }
    
             mail.Body = szMailBody;
    
             mail.Subject = szMailSubject;
    
             //Send Email.
             try
             {
                client.Send(mail);
                bSuccess = true;
             }
             catch (Exception Ex)
             {
                bSuccess = false;
             }
    
             // Clean up.
             mail.Dispose();
    
    
             return bSuccess;
    
          }
    
       }
