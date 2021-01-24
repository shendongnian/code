    public ActionResult RequestBookingCustomer(BookingViewModel bvm)
    {
                _context.Booking.Add(bvm.Booking);              
                _context.Messages.Add(bvm.Messages);
                _context.PetInformation.Add(bvm.Pets);
                _context.SaveChanges();
                // redirect to get booking details action medthod
                return RedirectToAction("BookingDetails", new { BookingId = bvm.BookingId});
    }
