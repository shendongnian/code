    [HttpPost, ActionName("Create")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> CreatePOST()
            {
                if (ModelState.IsValid)
                {
                    _db.Garancija.Add(GarancijaVM.Garancija);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(GarancijaVM);
            }
