	var nodes = new List<Node>()
	{
		new Node { Id = 1, Name = "Node #1", ParentId = null },
		new Node { Id = 2, Name = "Node #2", ParentId = 1 },
		new Node { Id = 3, Name = "Node #3", ParentId = 2 },
		new Node { Id = 4, Name = "Node #4", ParentId = null },
		new Node { Id = 5, Name = "Node #5", ParentId = 2 },
		new Node { Id = 6, Name = "Node #6", ParentId = 2 },
		new Node { Id = 7, Name = "Node #7", ParentId = 1 },
		new Node { Id = 8, Name = "Node #8", ParentId = 5 },
		new Node { Id = 9, Name = "Node #9", ParentId = 4 },
		new Node { Id = 10, Name = "Node #10", ParentId = 4 },
	};
	var lookup = nodes.ToLookup(x => x.ParentId);
	
	IEnumerable<Node> Flatten(int? parentId)
	{
		foreach (var node in lookup[parentId])
		{
			yield return node;
			foreach (var child in Flatten(node.Id))
			{
				yield return child;
			}
		}	
	}
	var output = Flatten(null).ToArray();
