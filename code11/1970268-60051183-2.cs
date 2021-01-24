    public static void Main()
	{
		var list = new[] {new Foo { Property1 = "foo1" }, new Foo { Property1 = "foo2" }};
		
		var result = list.SelectDynamic(nameof(property).toString());
		
		result.Dump();
	}
