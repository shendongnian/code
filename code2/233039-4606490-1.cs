    public class IndexModel
    {
        IList<UserInfo> Users { get; set; }
    }
    public class UserInfo // or whatever makes the most sense
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string[] Roles { get; set; }
    }
