    class User : IdentityUser
    {
        [Required]
        public new string Email { get; set; }
    }
