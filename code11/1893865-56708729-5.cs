    public class Address
    {
        public virtual int AddressID { get; set; }
        public virtual string Street { get; set; }
        public virtual string CityStateZip { get; set; }
        [Required]
        public virtual Person AddressOf { get; set; }
    }
