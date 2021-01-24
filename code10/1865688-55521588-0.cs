     public class Booking
    {
        public int Id { get; set; }
        public DateTime Transdate { get; set; }
        public string HotelName { get; set; }
        public string HotelAddress { get; set; }
        public ICollection<BookingItem> BookingItems { get; set; }
    }
