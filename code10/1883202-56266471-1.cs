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
	var searchText = "fred*smith";
	
	var wildcard =
		new Regex(
			String.Join(".*",
				searchText
					.Split('*')
					.Select(x => Regex.Escape(x))));
	
	var results =
		products
			.Where(p => new []
			{
				p.Name, p.Size, p.ProductId, p.Category
			}.Any(x => wildcard.IsMatch(x)));
