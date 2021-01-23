    public class ElmahLogger : ILogger
    {
        public void LogError(Exception ex, string contextualMessage = null, bool withinHttpContext = true)
        {
            try
            {
                var exc = contextualMessage == null 
                          ? ex 
                          : new ContextualElmahException(contextualMessage, ex);
                if (withinHttpContext)
                    ErrorSignal.FromCurrentContext().Raise(exc);
                else
                    ErrorLog.GetDefault(null).Log(new Error(exc));
            }
            catch { }
        }
    }
