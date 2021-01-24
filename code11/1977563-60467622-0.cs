    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string password { get; set; }
        [Column("roleId")]
        public int roleId { get; set; }
        public Role role { get; set; }
    }
