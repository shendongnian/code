    public class CustomerBillTo 
    {
        [Required]
        [ForeignKey("Customer")]
        public string CustomerId { get; set; }
         
        public virtual Customer Customer { get; set; }
    }
