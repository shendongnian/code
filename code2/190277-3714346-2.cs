    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
    
        public virtual Profile Profile { get; set; }
    }
    
    public class Profile
    {
        public int Id { get; set; }
    
        public int UserID { get; set; }
    
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PostalCode { get; set; }
    }
