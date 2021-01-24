    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create( Client client)
     {
            if (ModelState.IsValid)
            {
                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(client);
      }
