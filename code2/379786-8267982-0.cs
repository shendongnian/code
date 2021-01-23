    class Product
    {
        public string Name { get; set; }
        public int Sales { get; set; }
    }
    
    [TestMethod]
    public void SalesTest()
    {
        var products = Builder<Product>.CreateListOfSize(4)
             .TheFirst(1)
             .With(x => x.Sales = 20)
             .AndTheNext(1)
             .With(x => x.Sales = 5)
             .AndTheNext(1)
             .With(x => x.Sales = 3)
             .AndTheNext(1)
             .With(x => x.Sales = 100).Persist();
    
        var result = SystemUnderTest.Execute();
    
        Assert.AreEqual(3, result.Count);
    
        Assert.AreEqual(100, result[0].Sales);
        Assert.AreEqual(20, result[0].Sales);
        Assert.AreEqual(5, result[0].Sales);
    }
