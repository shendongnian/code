     public class BookingVM
    {
        public Booking Booking { get; set; }
        public List<BookingItem> BookingItems { get; set; }
        public ApplicationDbContext db = new ApplicationDbContext();
        public void Initiate()
        {
            Booking = new Booking();
            BookingItems = new List<BookingItem>();
            // Get All Type of Room
            foreach (var item in Enum.GetValues(typeof(RoomType)))
            {
                  BookingItem _item = new BookingItem
                    {
                        RoomType = (RoomType)item,
                        Qty = 0,
                        BookingId = 0
                    };
                  BookingItems.Add(_item);
            }
        }
        public void AddBooking()
        {
            Booking.BookingItems = new List<BookingItem>();
            
            foreach (var item in BookingItems)
	        {
                Booking.BookingItems.Add(item);
	        }
            db.Bookings.Add(Booking);
        }
    }
