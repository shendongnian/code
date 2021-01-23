    ThreadPool.QueueUserWorkItem(callback =>
                    {
                        var mailMessage = new MailMessage
                        {
                            ...
                        };
                        
                        //if you need any references in handlers
                        object userState = new ReturnObject
                        {
                            MailMessage = mailMessage,
                            SmtpClient = smtpServer
                        };
                        smtpServer.SendCompleted += HandleSmtpResponse;
                        smtpServer.SendAsync(mailMessage, userState);
                    });
