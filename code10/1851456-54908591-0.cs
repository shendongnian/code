	public ActionResult GetProducts(List<string> filter)
	{
		List<Product> proc = new List<Product>();
		IQueryable<Product> query = db.Product;
		foreach (var item in filter)
			query = query.Where(x => x.tMal.Contains(item));
		proc.AddRange(query.ToList());
		
		return View(proc);
	}
