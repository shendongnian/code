    public class DepositTicket
    {
        [Required]
        [Display(Name="Deposit Amount")]
        [Range(5.00, 999999999999999999999999999.0, ErrorMessage = "Price must be above $5")]
        public decimal Amount { get; set; }
    }
