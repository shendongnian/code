    [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Code,Libelle")] Marque marque)
            {
                if (ModelState.IsValid)
                {
                    var codeExists = _context.Marque.Where(s => s.Code == marque.Code).FirstOrDefault().Code == marque.Code ? "yes" : "no";
                    if (codeExists == "no")
                    {
                        _context.Add(marque);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError("Code","This code already exists");
                    }
                }
                return View(marque);
            }
