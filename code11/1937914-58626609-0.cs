    public bool SlotAvailable(Item item) 
    {
        return !_context.bookings
            .Any(booking => 
                item.StartTime < booking.EndTime 
                && item.EndTime > booking.StartTime);
    }
