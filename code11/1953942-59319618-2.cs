    public IActionResult DropDownList()
        {
            ViewBag.Studio = new SelectList(_context.Studios.FromSql("GetStudio"), "Id", "Name");
            ViewBag.City = new SelectList(_context.Cities.FromSql("GetCity"), "Id", "Name");
            ViewBag.Address = new SelectList(_context.Addresses.FromSql("GetAddress"), "Id", "Street");
            return View();
        }
