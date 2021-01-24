    var siteList = new List
    {
    	DisplayName = "Books",
    	Columns = new List<ColumnDefinition>()
    	{
    		new ColumnDefinition
    		{
    			Name = "Author",
    			Text = new TextColumn
    			{
    			}
    		},
    		new ColumnDefinition
    		{
    			Name = "PageCount",
    			Number = new NumberColumn
    			{
    			}
    		}
    	},
    	List = new ListInfo
    	{
    		Template = "genericList"
    	}
    };
