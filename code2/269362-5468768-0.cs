	[Test]
	public void TestObjectIntersect()
	{
		var a = new List<object> { 1, 2, 3, "test", "test2" };
		var b = new List<object> { 4, 5, 1, "test2" };
		var c = a.Intersect(b);
		Console.WriteLine(String.Join(",", c.Select(x => x.ToString()).ToArray()));
	}
