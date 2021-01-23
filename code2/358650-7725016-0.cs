    public bool ConflictsWith(Booking booking)
    {
      // You may want to check they are for the same room here.
      return !(booking.EndDate <= this.StartDate || booking.StartDate >= this.EndDate);
    }
