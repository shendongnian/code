    public bool IsSessionTimeout
    {
        get
        {
            DateTime? sessionStart = Session[SessionKeys.SessionStart] as DateTime?;
            bool isTimeout = false;
            if (!sessionStart.HasValue)
            {
                // If sessionStart doesn't have a value, the session has been cleared, 
                // so assume a timeout has occurred.            
                isTimeout = true;
            }
            else
            {
                // Otherwise, check the elapsed time.
                TimeSpan elapsed = DateTime.Now - sessionStart.Value;
                isTimeout = elapsed.TotalMinutes > Session.Timeout;
            }
            Session[SessionKeys.SessionStart] = DateTime.Now;
            return isTimeout;
        }
    }
