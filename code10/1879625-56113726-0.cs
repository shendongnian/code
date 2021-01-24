	[TestMethod]
	public void Method1() {
		var db = new U2Db();
		var o = new Order() {Tag="Method1"};
		db.Orders.Add(o);
		db.TrySave(); //custom extension. wraps SaveChanges and reports errors if exist
	
		//checks inner db tables, service broker queues etc. 
		....
	}
