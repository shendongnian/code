    [Test]
    public void FooTest()
    {
        var productList = new List<string>();
    
        var productNameList = new ProductNameList(productList);
    
        productNameList.AddProductName("Foo");
    
        Assert.IsTrue(productList[0] == "Foo");
    }
