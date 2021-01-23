    [Test]
    public void Customer_Should_Have_CreateAt_Set_To_Today{
      var mock = new Mock<IRepository>();
      mock.Setup(GetCustomer).Returns(new Customer{id = 1, Name = "Steve"});
    
      var Customer = mock.Object;
      Assert.Equal(Customer.CreatedAt,Date.Today);
    }
