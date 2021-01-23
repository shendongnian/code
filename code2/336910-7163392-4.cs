    [Test]
    public void ShouldReturnAllCustomersWithoutOrders()
    {
        var john = UnitTestHelper.MockCustomer("John").WithOrder(100).WithOrder(200);
        var paul = UnitTestHelper.MockCustomer("Paul");
        var george = UnitTestHelper.MockCustomer("George").WithOrder(15);
        var ringo = UnitTestHelper.MockCustomer("Ringo");
        var mockRepository = new Mock<Repository()
            .HavingCustomers(john, paul, george, ringo);
        var custServ = new CustomerService(mockRepository.Object);
        var customersWithoutOrders = custServ.GetCustomersWithoutOrders();
        Assert.That(customersWithoutOrders.Count(), Is.EqualTo(2));
        Assert.That(customersWithoutOrders, Has.Member(paul));
        Assert.That(customersWithoutOrders, Has.Member(ringo));
    }
