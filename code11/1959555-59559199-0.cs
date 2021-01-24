    public async Task<IActionResult> Index(int page = 1) {
    var qry = _context.Suppliers.AsNoTracking().OrderBy(p => p.CompanyName);
    var model = await PagingList.CreateAsync(qry, 10, page);
    return View(model);
    }
