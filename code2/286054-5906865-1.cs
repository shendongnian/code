    mem = (log4net.Appender.MemoryAppender)LogHelper.GetSpecificAppenderInRoot("ErrorHolder");
                    if (mem != null)
                    {
                        var errorHasOccured = mem.GetEvents().FirstOrDefault(x => x.Level == log4net.Core.Level.Error);
                        if (errorHasOccured == null)
                        {
                            // there was no error so dont send the email containg every thing, AppenderName: 
                            appender = (log4net.Appender.SmtpAppender)LogHelper.GetSpecificAppenderInRoot("Email");
                            if (appender != null)
                            {
                                appender.Threshold = log4net.Core.Level.Off;
                                appender.ActivateOptions();
                            }
                        }
                    }
                    else
                    {
                        appender = (log4net.Appender.SmtpAppender)LogHelper.GetSpecificAppenderInRoot("Email");
                        if (appender != null)
                        {
                            appender.Threshold = log4net.Core.Level.Off;
                            appender.ActivateOptions();
                        }
                    }
