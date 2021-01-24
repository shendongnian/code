    var mockUserRepo = new Mock<ICustomerInquiryMockRepository>();
    mockUserRepo.Setup(x => x.GetCustomers())
                .Returns(Task.FromResult(MockData.Current.Customers.AsEnumerable());
    mockUserRepo.Setup(x => x.GetCustomer(It.IsAny<int>()))
                .Returns(res => Task.FromResult(MockData.Current.Customers.ElementAt(res));
