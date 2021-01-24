    public async Task<IActionResult> Index(string filter) {
        var passengers = _context.Passengers
            .Select(a => new PassengerViewModel
            {
                Id = a.Id,
                FirstName = a.FirstName,
                Surname = a.Surname,
                Email = a.Email,
            });
        if (!String.IsNullOrEmpty(filter)) {
            passengers = passengers.Where(e => 
                e.FirstName?.Contains(filter) || 
                e.Surname?.Contains(filter)
            );
        }
        return View(await passengers.ToListAsync());
    }
