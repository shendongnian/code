    public class AccountViewModel
    {
        [Required(ErrorMessage="Account Number is Required")]
        public string AccountNumber { get; set; }
        [ReversStringMatch(ErrorMessage = "The value doesn't match the Account Number", Property="AccountNumber")]
        public string ReverseAccountNumber { get; set; }            
    }
