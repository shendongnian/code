    public async Task<IActionResult> Index(int pageIndex = 1)
    {
        var qry = _context.Products.AsNoTracking().OrderBy(u => u.Id);
        var model = await PagingList.CreateAsync(qry, 6, pageIndex);
        return View(model);
    }
