    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public UserType Type { get; set; }
    }
    
    public enum UserType
    {
        Admin = 1,
        Client = 2,
    }
