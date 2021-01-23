    public class Organisation : Customer
    {
        [Column(Name = "FinancialContact")]
        public int? FinancialContactId { get; set; }
        [ForeignKey("FinancialContactId")]
        public Person FinancialContact { get; set; }
        [Column(Name = "MainContact")]
        public int? MainContactId { get; set; }
        [ForeignKey("MainContactId")]
        public Person MainContact { get; set; }
    }
