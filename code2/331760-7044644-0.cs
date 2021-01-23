    public static class CustomPrincipalExtensions
    {
        public static string Email(this CustomPrincipal cUser)
        {
            return cUser != null ? cUser.Email : "Default Email"
        }
        public static string UserID(this CustomPrincipal cUser)
        {
            return cUser != null ? cUser.UserID : "Default ID"
        }
    }
