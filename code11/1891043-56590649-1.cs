                public async Task<IActionResult> Create([Bind("Id,Name")] Model model)
                {
                        ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);
                        if (ModelState.IsValid)
                        {
                                model.Publisher = user;
                                _context.Add(model);
                                await _context.SaveChangesAsync();
                                return RedirectToAction(nameof(Index));
                        }
                        return View(model);
                }
