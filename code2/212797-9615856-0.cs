            private void SendMailAsync(string ids, MailMessage mail)
        {
            SmtpClient client = null;
            try
            {
                client = new SmtpClient(ConfigurationManager.AppSettings["MailServer"], Convert.ToInt32(ConfigurationManager.AppSettings["MailPort"]));
                
                string userState = "MailQueueID_" + ids;
                client.SendCompleted += (sender, e) =>
                {
                    // Get the unique identifier for this asynchronous operation
                    String token = (string)e.UserState;
                    DateTime now = DateTime.Now;
                    try
                    {
                        if (e.Cancelled)
                        {
                            LogError(new Exception(token + " - Callback cancelled"));
                            return;
                        }
                        if (e.Error != null)
                        {
                            LogError(e.Error);
                        }
                        else
                        {
                            logWriter.WriteToLog(this.jobSite + " - " + token + " (Email sent)");
                            try
                            {
                                int updated = UpdateMailQueue(token, now);
                                if (updated > 0)
                                {
                                    // Update your log
                                }
                            }
                            catch (SqlException sqlEx)
                            {
                                LogError(sqlEx);
                            }
                        }
                    }
                    catch (ArgumentNullException argument)
                    {
                        LogError(argument);
                    }
                    finally
                    {
                        client.SendCompleted -= client_SendCompleted;
                        client.Dispose();
                        mail.Dispose();
                        // Delete the attachment if any, attached to this email
                        DeleteZipFile(token);
                        
                        counter--;
                    }
                };
                client.SendAsync(mail, userState);
                counter++;
            }
            catch (ArgumentOutOfRangeException argOutOfRange)
            {
                LogError(argOutOfRange);
            }
            catch (ConfigurationErrorsException configErrors)
            {
                LogError(configErrors);
            }
            catch (ArgumentNullException argNull)
            {
                LogError(argNull);
            }
            catch (ObjectDisposedException objDisposed)
            {
                LogError(objDisposed);
            }
            catch (InvalidOperationException invalidOperation)
            {
                LogError(invalidOperation);
            }
            catch (SmtpFailedRecipientsException failedRecipients)
            {
                LogError(failedRecipients);
            }
            catch (SmtpFailedRecipientException failedRecipient)
            {
                LogError(failedRecipient);
            }
            catch (SmtpException smtp)
            {
                LogError(smtp);
            }
        }
