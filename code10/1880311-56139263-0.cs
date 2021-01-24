    public ActionResult AddBooking(BookingViewModel booking, MessageViewModel message)
    {
       var newBooking = new Booking { BookedDate = booking.BookedDate, /* ... */ };
       _context.Bookings.Add(newBooking);
       if (message != null)
       {
         var newMessage = new Message { MessageText = message.Text, Booking = newBooking };
         _context.Messages.Add(newMessage);
       }
       _context.SaveChanges();
    }
