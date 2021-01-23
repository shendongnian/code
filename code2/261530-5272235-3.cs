    public class RegisterAssetCommand
    {
        [Required]
        public int CaseNumber { get; set; }
        [Required]
        public User Operator { get; set; }
    }
