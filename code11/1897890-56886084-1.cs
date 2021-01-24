    static void Foo()
    {
    	var columnNameList = new string[] { "ID", "Title", "Description" };
    	var tasksList = new List<Tasks>
    	{
    		new Tasks{ ID=1, Title="T1", FirstName="F1", LastName="L1", Description="D1", Date=DateTime.UtcNow },
    		new Tasks{ ID=2, Title="T2", FirstName="F2", LastName="L2", Description="D2", Date=DateTime.UtcNow }
    	};
    
    	var tasks = tasksList.Select(CreateSelect(columnNameList)).FirstOrDefault();
    }
