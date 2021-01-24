    public class ForumPost
    {
        [Key]
        public int PostId { get; set; }
        [Required]
        [MaxLength(32)]
        public string PostName { get; set; }
        [Required]
        public string PostBody { get; set; }
        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
