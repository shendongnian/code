    public class User_
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    
    public class RootObject
    {
        public User_ User { get; set; }
    }
