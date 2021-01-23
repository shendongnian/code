    public class Email
    {
        [Key]
        public int EmailID { get; set; }
        public int PersonId { get; set; }
        [Unique]
        [Required]
        [MaxLength(100)]
        public string EmailAddress { get; set; }
        public virtual bool IsDefault { get; set; }
        public virtual Boolean IsApprovedForLogin { get; set; }
        public virtual String ConfirmationToken { get; set; }
        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }
    }
