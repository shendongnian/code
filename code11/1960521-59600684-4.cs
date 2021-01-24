    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Surname,FirstName,Email")] PassengerViewModel model)
    {
        if (ModelState.IsValid)
        {
            Passenger passenger = new Passenger
            {
                Id = model.Id,
                FirstName = model.FirstName,
                Email = model.Email
            };
            await _context.Passengers.AddAsync(passenger);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
                
        return View(passenger);
    }
