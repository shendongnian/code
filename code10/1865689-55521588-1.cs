        public class BookingItem
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public int? Qty { get; set; }
        public RoomType RoomType { get; set; }
        public virtual Booking Booking { get; set; }
    }
    public enum RoomType { 
    Small, Medium, Large, ExtraBed}
