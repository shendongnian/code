    [TestMethod]
    public void SomeLookupTest()
    {
    	LookupGetter getter = new LookupGetter();
    
    	LookupTester.CompareEnumWithDatabase(
    		getter.GetItems(LookupName.Schema__SomeLookup),
    		typeof(SomeLookupEnumType)
    	);
    }
