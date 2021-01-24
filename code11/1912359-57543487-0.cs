class MyContext : DbContext
{
    ...
    // In case your nameTable1[] arrays are of type object[]
	public void AddRange(params object[] data)
	{
		if (!data.Any()) return;
		
		var entityType = data[0].GetType();
		Set(entityType).AddRange(data);
	}
	public void AddRange<T>(params T[] data)
		where T : class
	{
		Set<T>().AddRange(data);
	}
	public void AddRange<T>(IEnumerable<T> data)
		where T : class
	{
		Set<T>().AddRange(data);
	}
}
