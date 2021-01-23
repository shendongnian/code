    [TestMethod]
    [UseReporter(typeof(DiffReporter))]
    public void TestMethod1()
    {
        var fred = new Person{
           		Age = 35,
			FirstName = "fred",
			LastName = "Flintstone",
			Hair = Color.Black
		       };
        Approvals.Verify(fred.WritePropertiesToString());
    }
