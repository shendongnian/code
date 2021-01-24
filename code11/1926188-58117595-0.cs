        [HttpPost]
        public async Task<IActionResult> Create(VehicleModel newModel)
        {
            if (!ModelState.IsValid)
                return View(newModel);
            _context.Add(newModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
