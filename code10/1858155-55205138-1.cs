    public class User
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        public Guid AuthenticationId { get; set; }
        // Even this navigation property is optional
        // for configuring one-to-one relationship
        public virtual Authentication Authentication { get; set; }
    }
    public Authentication
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
    }
