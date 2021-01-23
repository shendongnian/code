    public static class SessionExtensions
    {
        public static string GetString(this HttpSessionStateBase session, string key)
        {
            if (session == null)
            {
                return string.Empty;
            }
            var value = session[key];
            if (value == null)
            {
                return string.Empty;
            }
            return Convert.ToString(value);
        }
    }
