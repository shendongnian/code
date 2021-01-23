    using Elmah;
    public static class ErrorLog
    {
        /// <summary>
        /// Log error to Elmah
        /// </summary>
        public static void LogError(Exception ex, string message=null)
        {
            try
            {
                // log error to Elmah
                if (friendlyMessage != null) 
                {
                    var annotatedException = new Exception(message, ex); 
                    ErrorSignal.FromCurrentContext().Raise(annotatedException, HttpContext.Current);
                }
                else 
                {
                    ErrorSignal.FromCurrentContext().Raise(ex, HttpContext.Current);
                }
                // send errors to ErrorWS (my own legacy service)
                using (ErrorWSSoapClient client = new ErrorWSSoapClient())
                {
                    client.LogErrors(...);
                }
            }
            catch (Exception)
            {
                // uh oh! just keep going
            }
        }
    }
