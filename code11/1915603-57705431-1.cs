        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Studio studio)
        {
            if (id != studio.StudioID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var st = _context.Studios.FirstOrDefault(n => n.StudioID == studio.StudioID);
                    st.Name = studio.Name;
                    _context.Update(st);
                    foreach(var i in studio.StudioAddresses)
                    {
                        var address = _context.Addresses.FirstOrDefault(n=>n.AddressID == i.AddressID);
                        address.Street = i.Address.Street;
                        _context.Update(address);
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudioExists(studio.StudioID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(studio);
        }
