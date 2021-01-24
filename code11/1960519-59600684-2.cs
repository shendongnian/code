    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Surname,FirstName,Email")] PassengerViewModel passenger)
    {
        if (ModelState.IsValid)
        {
            PassengerViewModel model = new PassengerViewModel
            {
                Id = passenger.Id,
                FirstName = passenger.FirstName,
                Email = passenger.Email
            };
            await _context.Passengers.AddAsync(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
                
        return View(passenger);
    }
