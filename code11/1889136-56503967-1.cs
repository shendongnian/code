	var map = new Dictionary<string,Func<Node,IComparable>>
	{
		{ "PropertyA", node => node.PropertyA },
		{ "PropertyB", node => node.PropertyB }
	};
	
	IEnumerable<Node> list = new Node[]
	{
		new Node { PropertyA = 1, PropertyB = "Z" },
		new Node { PropertyA = 2, PropertyB = "A" },
		new Node { PropertyA = 2, PropertyB = "B" }
	};
	
	
	var sortBy = new string[] { "PropertyA", "PropertyB" };
							
	foreach (var sortKey in sortBy.Reverse())
	{
		list = list.OrderBy( map[sortKey] );
	}
	
	foreach (var node in list)
	{
		Console.WriteLine("{0} {1}", node.PropertyA, node.PropertyB);
	}
