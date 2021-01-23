    public static class HttpSessionStateExtensions
    {
        public static bool IsLoggedOut(this HttpSessionState instance)
        {
            return instance[Common.SessionVariables.IsLogout] == true.ToString();
        }
        public static bool SetIsLoggedOut(this HttpSessionState instance, bool value)
        {
            instance[Common.SessionVariables.IsLogout] = value.ToString();
        }
    }
