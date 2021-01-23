    class Booking
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RoomNumber { get; set; }
    }
    
    bool IsRoomAvailableOnDate(int roomNumber, DateTime date)
    {
        //change this to match your data source
        List<Booking> bookings = Booking.GetBookings();
    
        // get all bookings that have a start date and end date within your timeframe
        var bookingsWithinDate = from booking in bookings
                                    where booking.RoomNumber == roomNumber
                                    && booking.StartDate <= date
                                    && booking.EndDate >= date
                                    select booking;
    
        if (bookingsWithinDate.Any())
        {
            //bookings found that match date and room number
            return false;
        }
        else
        {
            //no bookings
            return true;
        }
    }
