    public class User
    {
        public int UserId { get; set; }
        [InverseProperty("Creator")]
        public virtual ICollection<User> CreatedUsers { get; set; }
        [InverseProperty("Modifier")]
        public virtual ICollection<User> ModifiedUsers { get; set; }
        [Required]
        public virtual User Creator { get; set; }
        [Required]
        public virtual User Modifier { get; set; }
    }
