    [HttpPost]
    public async Task<IActionResult> AddOrder([Bind("Id,Name,Location,Price,Description")] Order order)
    { 
        //Gets the ID of the currently logged user
        string userId = _userManager.GetUserId(HttpContext.User);
        if (ModelState.IsValid)
        {
            var newOrder = New Order
            {
                Id = order.Id,
                Name = order.Name,
                Location = order.Location,
                Price = order.Price,
                Description = order.Description,
                //Here you make the relation between the order and the user that made it
                IdentityUserId = userId
            }
            _context.Add(newOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(order);
    }
