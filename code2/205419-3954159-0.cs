    [TestMethod]
    public void GetCustomerTest()
    {
        const int customerId = 5;
    
        var mockCustomer = new Mock<Customer>();
    
        mockCustomer.SetupGet(x => x.CustomerId)
            .Returns(customerId);
    
        var mock = new Mock<IRepository<Customer>>();
    
        mock.Setup(x => x.Get(It.IsAny<Expression<Func<Customer, bool>>>()))
            .Returns(mockCustomer.Object);
    
        var repository = mock.Object;
        var service = new CustomerService(repository);
        var result = service.GetCustomerById(customerId);
    
        Assert.AreEqual(customerId, result.CustomerId);
    }
