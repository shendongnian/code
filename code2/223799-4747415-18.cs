    int id = 0;
    var tags = new[]
    {
    	new Tag
    	{
    		Id = ++id,
    		TagName = "Parent", 
    		ChildNodes = new[]
    		{
    			new Tag { TagName = "Child1", Id = ++id, ParentId = 1  },
    			new Tag { TagName = "Child2", Id = ++id, ParentId = 1  }
    		}
    	}
    	new Tag
    	{
    		Id = ++id,
    		TagName = "NoChildren"
    	}
    };
