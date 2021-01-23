    [TestMethod]
    public void Find_Method_MustReturn_Customer_Orders_ItemsWithinOrder()
    {
        Customer c = _rep.Find(6).SingleOrDefault();
        Assert.IsTrue(c.Orders.Any());      
        Assert.IsTrue(c.Orders.Any(x => x.Items.Any());                        
    }
