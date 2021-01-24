    public class PersonalisationState
    {
        public UserType UserType { get; set; }
        public UserRole UserRole { get; set; }
        public BookingPeriod BookingPeriod { get; set; }
        public PersonalisationState(BookingSummary booking)
        {
            if (booking == null) return;
            UserRole = UserRole.Parse(booking.UserRole);
            UserType = new UserType(booking.UserType);
            BookingPeriod = new BookingPeriod {BookingPeriodType = booking.BookingPeriod};
        }
    }
