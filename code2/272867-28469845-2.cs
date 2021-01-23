    [TestMethod]
    public void Test_IsAssignableFrom()
    {
    	var manager = new Manager();
        // Manager derives from Employee so the below is true
	    Assert.IsInstanceOf<Employee>(manager);   
    }
