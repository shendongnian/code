    [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAccommodation([FromForm]Accommodations accommodation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accommodation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accommodation);
        }
