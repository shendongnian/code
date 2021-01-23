    var booking = (from b in data.Bookings
                   where b.BookingId = bookingId
                   select new BookingSearchResult // You have to create this class
                              {
                                  CheckinDate = new DateTime(b.CheckinYear, b.CheckinMonth, b.CheckinDay),
                                  CheckoutDate = new DateTime(b.CheckoutYear, b.CheckoutMonth, b.CheckoutDay)
                              }).SingleOrDefault();
