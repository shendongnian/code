    public ActionResult AddBooking(BookingViewModel booking, MessageViewModel message)
    {
       var newBooking = new Booking { BookedDate = booking.BookedDate, /* ... */ };
       if (message != null)
       {
         var newMessage = new Message { MessageText = message.Text, Booking = newBooking };
         newBooking.Messages.Add(newMessage);
       }
       _context.Bookings.Add(newBooking);
       _context.SaveChanges();
    }
