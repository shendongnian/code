    public async Task<IActionResult> Index()
    {
         var test = await (from ep in _context.Products
                 join e in _context.Suppliers on ep.SupplierId equals e.SupplierId
                 where (e.SupplierId == 1)
                 select new ProductViewModel
                 {  
                    ep.ProductName,
                    e.CompanyName
                 }).ToListAsync();
    }
    return View(test);
