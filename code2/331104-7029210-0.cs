    [WebMethod]
    public static bool HasSessionTimedOut()
    {
        HttpSessionState session = HttpContext.Current.Session;
 
        // I put this value into Session at the beginning.
        DateTime? sessionStart = session[SessionKeys.SessionStart] as DateTime?;
        bool isTimeout = false;
    
        if (!sessionStart.HasValue)
        {
            isTimeout = true;
        }
        else
        {
            TimeSpan elapsed = DateTime.Now - sessionStart.Value;
            isTimeout = elapsed.TotalMinutes > session.Timeout;
        }
    
        return isTimeout;
    }
