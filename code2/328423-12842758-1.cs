    public class EditUserModel
    {
        public UserModel User { get; set; }
    
        [Required]
        public string PasswordConfirmation { get; set; }
    }
