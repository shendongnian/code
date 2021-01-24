    public class PersonalisationState
        {
            public UserType UserType { get; set; }
            public UserRole UserRole { get; set; }
            public BookingPeriod BookingPeriod { get; set; }
            public PersonalisationState(BookingSummary booking)
            {
                // Add Error checking to ensure booking.UserType, UserRole or others are not null
                this.UserType = new UserType() { userType = booking.UserType };
                this.UserRole = new UserRole() { roleName = booking.UserRole };
                this.BookingPeriod = new BookingPeriod() {periodName = booking.BookingPeriod};
            }
        }
You can use it in your main or anywhere like
BookingSummary book = new BookingSummary() { /* with Values */ };
PersonalisationState pers = new PersonalisationState(book);
