    public class User
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public String UserAddress { get; set; }
    
        [InverseProperty("Friends")]
        public virtual ICollection<User> FriendWith { get; set; }
        [InverseProperty("FriendWith")]
        public virtual ICollection<User> Friends { get; set;} 
    }
