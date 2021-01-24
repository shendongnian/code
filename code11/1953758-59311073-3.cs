    private PersonalisationState Convert(BookingSummary booking)
    {
        return booking == null
            ? null
            : new PersonalisationState
            {
                UserRole = UserRole.Parse(booking.UserRole),
                UserType = new UserType(booking.UserType),
                BookingPeriod = new BookingPeriod {Name = booking.BookingPeriod}
            };
    }
