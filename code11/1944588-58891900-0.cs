    public async Task<IActionResult> Index(string search = null)
        {
            if (!string.IsNullOrEmpty(search))
            {
                var foundItems = SearchItem(search);
                return View(foundItems);
            }
    
            return PartialView(await _context.Storage.ToListAsync());
        }
