    public static class UserManager 
    {
        [PrincipalPermission(SecurityAction.Demand, 
            Role = "Administrators")]
        public static void AddUser(int userId) { }
    }
