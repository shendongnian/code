    public class Account : CoreObjectBase<Account>
    {
        public virtual int AccountId { get; set; }
        [Required(ErrorMessage = "Email address is required.")]
        public virtual string EmailAddress { get; set; }
        [Required(ErrorMessage = "A password is required.")]
        public virtual string Password { get; set; }
    }
