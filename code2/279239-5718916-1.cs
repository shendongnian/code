    class ExceptionHandler
        {
            public static void SendExceptionEmail(Exception ex, string ErrorLocation, string UserName, string url)
            {
                SmtpClient mailclient = new SmtpClient();
                try
                {
                    string errorMessage = string.Format("User: {0}\r\nURL: {1}\r\n=====================\r\n{2}", UserName, url, AddExceptionText(ex));
                    mailclient.Send(ConfigurationManager.AppSettings["ErrorFromEmailAddress"],
                                    ConfigurationManager.AppSettings["ErrorEmailAddress"],
                                    ConfigurationManager.AppSettings["ErrorEmailSubject"] + " = " + ErrorLocation,
                                    errorMessage);
                }
                catch { }
                finally { mailclient.Dispose(); }
            }
    
            private static string AddExceptionText(Exception ex)
            {
                string innermessage = string.Empty;
                if (ex.InnerException != null)
                {
                    innermessage = string.Format("=======InnerException====== \r\n{0}", ExceptionHandler.AddExceptionText(ex.InnerException));
                }
                string message = string.Format("Message: {0}\r\nSource: {1}\r\nStack:\r\n{2}\r\n\r\n{3}", ex.Message, ex.Source, ex.StackTrace, innermessage);
                return message;
            }
        }
