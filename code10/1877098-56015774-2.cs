    [HttpPost]
     public async Task<IActionResult> Create(NewCustomerviewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                viewmodel.Customers.MembershipTypes= _context.MembershipTypes
                                                     .Where(m =>viewmodel.SelectMembershipTypesId.Contains(m.Id))
                                                     .ToList();
                _context.Add(viewmodel.Customers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }
