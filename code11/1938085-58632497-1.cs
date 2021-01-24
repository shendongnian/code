	myObject = contex.TableName.GroupBy(t => t.Name)
	.Where(g => listOfNames.Contains(g.Key))
	.Select(g => new MyObject()
	{
		name = g.Key,
		number = g.Select(n => n.Number)
	});
