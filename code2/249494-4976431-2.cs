    [Test]
    public void Customer_Should_Have_CreateAt_Set_To_Today{
      var mock = new Mock<IRepository>();
      mock.Setup(x => x.GetCustomer(100)).Returns(new Customer{id = 100, Name = "Steve"});
    
      var Customer = mock.Object;
      Assert.Equal(Customer.CreatedAt,Date.Today);
    }
