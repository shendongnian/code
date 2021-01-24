    private PersonalisationState Convert(BookingSummary booking)
    {
        return new PersonalisationState
        {
            UserRole = UserRole.Parse(booking.UserRole),
            UserType = new UserType(booking.UserType),
            BookingPeriod = new BookingPeriod {BookingPeriodName = booking.BookingPeriod}
        };
    }
