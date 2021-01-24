	public static List<Product> GetProducts(List<int> ids)
	{
		var products = new List<Product>();
		foreach(var order in Orders)
		{
			products.AddRange(order.Products.Where(p => ids.Any(id => id == p.Id)));
		}
		
		return products;
	}
