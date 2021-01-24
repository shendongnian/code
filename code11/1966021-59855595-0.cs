public Product TryGetBestOne(IEnumerable<Product> products)
{
	var bestProducts = products
		.GroupBy(x => x.Price)
		.OrderBy(x => x.Key)
		.FirstOrDefault()?
		.ToArray() ?? Array.Empty<Product>();
	return bestProducts.Count() == 1 ? bestProducts.Single() : null;
}
