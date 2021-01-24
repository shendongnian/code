    using (var db = new DataConnection())
    {
    	db.GetTable<TestTable3>().InsertOrUpdate(
    		() => new TestTable3
    		{
    			Name = "Crazy Frog"
    		},
    		e => new TestTable3
    		{
    			Name = "Crazy Frog"
    		},
    		() => new TestTable3
    		{
    			ID = 5
    		});
    }
