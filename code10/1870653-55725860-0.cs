    IEnumerable<ObjectsModel> model = new List<ObjectsModel>()
    {
    	new ObjectsModel(){ Name = "John", Objects = "Orange" },
    	new ObjectsModel(){ Name = "John", Objects = "Banana" },
    	new ObjectsModel(){ Name = "John", Objects = "Apple" }
    };
    var htmlModel = model
    	.GroupBy(a => a.Name)
    	.Select(a => new
    	{
    		Name = a.Key,
    		GroupObjects = string.Join("", a.Select(b => $"<li>{b.Objects}</li>"))
    	})
    	.Select(a => $"<h1>{a.Name}</h1><ul>{a.GroupObjects}</ul>")
    	.ToList();
    var result = string.Join("", htmlModel); // <h1>John</h1><ul><li>Orange</li><li>Banana</li><li>Apple</li></ul>
