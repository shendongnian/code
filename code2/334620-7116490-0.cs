    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int CarId { get; set; }
        public DateTime BeginRentDate { get; set; }
        public DateTime EndRentDate { get; set; }
        public decimal RentPrice { get; set; }
        public virtual Car Car { get; set; }
    }
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string NumberPlate { get; set; }
        public decimal RentPrice { get; set; }
    }
