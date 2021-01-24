    public IActionResult Create()
            {
                ViewData["PassengerId"] = new SelectList(_context.Passengers, "Id", "Email");
                ViewData["FlightId"] = new SelectList(_context.Flights, "Id", "Name");
    
                return View();
            }
