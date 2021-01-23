	var current = new Record
		{ ImageId = 4, ParentImageId = 3, Name = "Sub Folder 2" };
	
	var records = new []
	{
		new Record { ImageId = 1, ParentImageId = 1, Name = "Folder 1" },
		new Record { ImageId = 2, ParentImageId = 1, Name = "Image 1" },
		new Record { ImageId = 3, ParentImageId = 1, Name = "Sub Folder 1" },
		current,
		new Record { ImageId = 5, ParentImageId = 4, Name = "Sub Image" },
	};
	
	var index = records.ToDictionary(r => r.ImageId);
	Func<Record, IEnumerable<Record>> traverseUp = null;
	traverseUp = r =>
	{
		var rs = new [] { r, };
		if (r.ParentImageId == r.ImageId)
		{
			return rs;
		}
		else
		{
			return traverseUp(index[r.ParentImageId]).Concat(rs);
		}
	};
	
	var breadcrumb = String.Join(" > ", traverseUp(current).Select(r => r.Name));
