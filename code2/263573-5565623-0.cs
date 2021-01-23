    public IQueryable<Product> GetProducts(int categoryID)
	{
		var productList = db.Products
			.Where(p => p.CategoryID == categoryID)
			.ToList()
			.Select(item => 
				new Product
				{
					Name = item.Name
				})
			.AsQueryable(); // actually it's not useful after "ToList()" :D
		
		return productList;
	}
