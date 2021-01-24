    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> TestCar([Bind("CarID,OwnerNIC")] CarOwner carOwner )
        {
            if (ModelState.IsValid)
            {
                var owner = new Owner()
                {
                    CarId = carOwner.CarID,
                    nic = carOwner.OwnerNIC
                };
                _context.Add(owner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carOwner);
        }
