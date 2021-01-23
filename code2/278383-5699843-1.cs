    public class Account
    {
        private List<string> _roles = new List<string>();
    
        public void IsTeacher
        {
            get { return _roles.Contains(AccountRoles.Teacher); }
        }
    }
    
    public static class AccountRoles
    {
        public const string Teacher = "Teacher";
    }
