    // NOTE: using Assert = NUnit.Framework.Assert;
    [TestMethod]
    public void Test_IsAssignableFrom()
    {
    	var employee = new Employee();
       
        // Manager is-a Employee, so the below is true
    	Assert.IsAssignableFrom<Manager>(employee);    
    }
