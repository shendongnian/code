    public async Task<IActionResult> Details(long? id)
            {
        
                var products = await _context.Products
                          .Include(p => p.Stock)
                              .ThenInclude(s => s.Storage)
                          .FirstOrDefaultAsync(p => p.ProductId == id);
        
                return View(products);
            }
