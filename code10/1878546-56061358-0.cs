C#
public async Task<Booking> CreateBookingAsync(Booking inBooking) {
  Booking booking = new Booking();
  ...
  await AddAsync(booking);
  return booking;
}
[Route("api/PostBooking")]
[HttpPost]
public async Task<IHttpActionResult> PostBooking(BookingSystemServiceBookingViewModel inBooking)
{
  ...
  uw.Services.AddBooking(await uw.Bookings.CreateBookingAsync(booking), inBooking.service.ServiceId);
  uw.Complete();
  return Ok();
}
If, on the other hand, it is the `Complete` method that actually communicates with the database, then *that* is the one that should be made asynchronous. In this case `Add` is purely an in-memory operation, and `Complete` is the one that saves all the database updates. So, *after* you convert `Complete` to `CompleteAsync`, your code would look like:
C#
public Booking CreateBooking(Booking inBooking) {
  Booking booking = new Booking();
  ...
  Add(booking);
  return booking;
}
[Route("api/PostBooking")]
[HttpPost]
public async Task<IHttpActionResult> PostBooking(BookingSystemServiceBookingViewModel inBooking)
{
  ...
  uw.Services.AddBooking(uw.Bookings.CreateBooking(booking), inBooking.service.ServiceId);
  await uw.CompleteAsync();
  return Ok();
}
