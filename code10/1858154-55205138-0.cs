    public class User
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        public Guid AuthenticationId { get; set; }
        public virtual Authentication Authentication { get; set; }
    }
    public Authentication
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
    }
