    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("PassengerId,IdF,Attended")] FlightBookingViewModel model)
            {
                if (ModelState.IsValid)
                {
                    FlightBooking flightBooking = new FlightBooking
                    {
                        PassengerId = model.PassengerId,
                        FlightId = model.FlightId,
                        Attended = model.Attended
                    }
                    await _context.Guests.AddAsync(flightBooking);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["PassengerId"] = new SelectList(_context.Customers, "Id", "Email", model.PassengerId);
                ViewData["FlightId"] = new SelectList(_context.Events, "Id", "Name", model.FlightId);
                return View(model);
            }
