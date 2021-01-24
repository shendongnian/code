    [Table("activitypoints")]
    public class UserActivityPoints
    {
        [Key]
        [Column("type")]
        public int Type { get; set; }
    
        [Column("amount")]
        public int Amount { get; set; }
    
        [Column("user_id")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
