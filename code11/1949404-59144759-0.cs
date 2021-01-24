    public async Task<IActionResult> List(string category, int page = 1)
            {
                IQueryable<Product> source = _repository.Products.Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.ProductID);
                var count = await source.CountAsync();
                var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
    
                PagingInfo pagingInfo = new PagingInfo(count, page, pageSize);
                ProductsListViewModel productsListView = new ProductsListViewModel
                {
                    PagingInfo = pagingInfo,
                    Products = items
                };
    
                return View(productsListView);}
