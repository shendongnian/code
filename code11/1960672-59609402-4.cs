    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string ClientID { get; set; }
    }
