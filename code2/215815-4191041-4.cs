    public static void RetryIfBusy(string server)
    {
        MailAddress from = new MailAddress("ben@contoso.com");
        MailAddress to = new MailAddress("jane@contoso.com");
        using (
            MailMessage message = new MailMessage(from, to)
                                      {
                                          Subject = "Using the SmtpClient class.",
                                          Body =
                                              @"Using this feature, you can send an e-mail message from an application very easily."
                                      })
        {
            message.CC.Add(new MailAddress("Notifications@contoso.com"));
            using (SmtpClient client = new SmtpClient(server) {Credentials = CredentialCache.DefaultNetworkCredentials})
            {
                Console.WriteLine("Sending an e-mail message to {0} using the SMTP host {1}.", to.Address, client.Host);
                try
                {
                    client.Send(message);
                }
                catch (SmtpFailedRecipientsException ex)
                {
                    foreach (var t in ex.InnerExceptions)
                    {
                        var status = t.StatusCode;
                        if (status == SmtpStatusCode.MailboxBusy || status == SmtpStatusCode.MailboxUnavailable)
                        {
                            Console.WriteLine("Delivery failed - retrying in 5 seconds.");
                            System.Threading.Thread.Sleep(5000); // Use better retry logic than this!
                            client.Send(message);
                        }
                        else
                        {
                            Console.WriteLine("Failed to deliver message to {0}", t.FailedRecipient);
                                // Do something better to log the exception
                        }
                    }
                }
                catch (SmtpException ex)
                {
                    // Here, if you know what to do about particular SMTP status codes,
                    // you can look in ex.StatusCode to decide how to handle this exception
                    // Otherwise, in here, you at least know there was an email problem
                }
                // Note that no other, less specific exceptions are caught here, since we don't know
                // what do do about them
            }
        }
    }
