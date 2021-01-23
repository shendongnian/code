    public class User {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<UserEmail> UserEmails { get; set; }
    }
    public class Email {
        public int EmailID { get; set; }
        public string Address { get; set; }
        public ICollection<UserEmail> UserEmails { get; set; }
    }
    public class UserEmail {
        public int UserID { get; set; }
        public int EmailID { get; set; }
        public bool IsPrimary { get; set; }
    }
