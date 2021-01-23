    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
    
        public ICollection<User> FollowedUsers { get; set; }
    }
