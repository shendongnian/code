    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public ICollection<PhoneNumber> phones { get; set; }
    }
    public class PhoneNumber
    {
        [Key, ForeignKey("Customer"), Column(Order = 1)]
        public int CustomerId { get; set; }
        [Key, Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PhoneNumberId { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public Customer customer { get; set; }
    }
