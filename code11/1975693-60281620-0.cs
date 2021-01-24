    public class UserForCreationDto
    {
        [Required]
        [MaxLength(100)]
        public string Username { get; set; } = "";
        [Required]
        [MaxLength(100)]
        public string Email { get; set; } = "";
    }
