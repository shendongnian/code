    public async Task<IActionResult> Index(int page = 1)
    {
          var qry = _context.Customer.AsNoTracking().OrderBy(c => c.Name);
          var model = await PagingList.CreateAsync(qry, 10, page);
          model.Action = "GetCustomers";
          return View(model);            
    }
