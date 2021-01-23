        public static class UserData
    {
        public static string FirstName;
        public static bool Register(string firstName)
        {
            bool success = false;
            //probably db related code here
            if (success)
            {
                FirstName = firstName;
                return true;
            }
            return false;
        }
    }
