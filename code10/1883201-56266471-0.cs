	var products = new List<Products>()
	{
		new Products()
		{
			Name = "theo frederick smith",
			Size = "",
			ProductId = "",
			Category = "brown",
		}
	};
	var searchText = "fred*brown";
	
	var splits = searchText.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
	
	var results =
		products
			.Where(p => splits.All(s =>
				p.Name.Contains(s)
				|| p.Size.Contains(s)
				|| p.ProductId.Contains(s)
				|| p.Category.Contains(s)));
