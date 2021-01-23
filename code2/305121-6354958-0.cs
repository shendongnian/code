    public static class HttpSessionStateExtensions
    {
        public static bool IsLoggedOut(this HttpSessionState instance)
        {
            return instance[Common.SessionVariables.IsLogout] == "true";
        }
    }
