    public static class SessionExtensions
    {
        public static bool HasHostAndUrl(this HttpSessionState session)
        {
            return session["CurrentUrl"] != null && session["CurrentHost"] != null;
        }
    }
    
