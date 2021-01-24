       public class UserRole : IdentityUserRole<string>
    {
        [Required, StringLength(36)]
        public string ClientId { get; set; }
        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
