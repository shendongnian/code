  public async Task<IActionResult> Create()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            string userId = currentUser.Id.ToString();
            ViewData["CustomerId"] = new SelectList(_context.Customers.Where(c => c.ApplicationUserId == userId), "ID", "Name");
            ViewData["CategoryId"] = new SelectList(_context.Categories.Where(p => p.ApplicationUserId == userId), "CategoryId", "CategoryName");
            ViewData["ProductId"] = new SelectList(_context.Products.Where(p => p.ApplicationUserId == userId), "ProductId", "ProductName");
            return View();
        }
