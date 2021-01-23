    public class RentalDetails
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
    
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        
        public DateTime DateRental { get; set; }
        public DateTime DateRestitution { get; set; }
    }
