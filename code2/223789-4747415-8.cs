    int id = 0;
    var tags = new[]
    {
    	new Tag
    	{
    		Id = ++id,
    		TagName = "Parent", 
    		ChildNodes = new[]
    		{
    			new Tag { TagName = "Child 1", Id = ++id, ParentId = 1  },
    			new Tag { TagName = "Child 1", Id = ++id, ParentId = 1  }
    		}
    	}
    	new Tag
    	{
    		Id = ++id,
    		TagName = "No children"
    	}
    };
    
    foreach (var t in tags.Where(t => t.ChildNodes == null))
    {
    	Console.WriteLine("{0} (0 sub tags)", t.TagName);
    }
    
    var groupping = from tag in tags.SelectMany(t => t.GetChildTags())
    				group tag by tag.ParentId into g
    				let parent = tags.FirstOrDefault(t => t.Id == g.Key)
    				select new { ParentName = (parent != null ? parent.TagName : null), Count = g.Count() };
    
    foreach (var entry in groupping)
    {
    	Console.WriteLine("{0} ({1} sub tags)", entry.ParentName, entry.Count);
    }
