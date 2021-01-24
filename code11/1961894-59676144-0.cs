    public class FlightBookingViewModel
    {
        public List<Passenger> Passengers { get; set; }
        public List<Flight> Flights { get; set; }
    
        public FlightBooking FlightBooking { get; set; }
    }
    public class Passenger
    {
        [Display(Name = "Passenger ID ")]
        public int IdC { get; set; }
    
        [Display(Name = "E-mail Address ")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
    public class Flight
    {
        [Display(Name = "Flight ID ")]
        public int IdF { get; set; }
    
        [Display(Name = "Flight Name ")]
        public string Name { get; set; }
    }
