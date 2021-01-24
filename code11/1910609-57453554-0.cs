`
public class EntityBase
    {
        public DateTime? CreatedAt { get; set; }
        public int CreatedById { get; set; }
        [ForeignKey("CreatedById")]
        public User CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int UpdatedById { get; set; }
        [ForeignKey("UpdatedById")]
        public User UpdatedBy { get; set; }
    }
`
`
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
`
