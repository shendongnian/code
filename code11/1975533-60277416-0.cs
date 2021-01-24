    private static async Task<List<Foo>> GetList()
	{
		var result = Enumerable.Empty<Foo>().AsQueryable();
		if (true)
		{
			IQueryable<Foo> part1 = new List<Foo> { new Foo() }.AsQueryable();
			result = result.Concat(part1);
		}
		if (true)
		{
			IQueryable<Foo> part2 = new List<Foo> { new Foo(), new Foo() }.AsQueryable();
			result = result.Concat(part2);
		}
        return await result.ToAsyncEnumerable().ToListAsync();
	}
