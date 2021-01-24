    [TestMethod]
    public async Task CustomerTest() {
        using (var mock = AutoMock.GetLoose()) {
            //For testing,Created dummy object of customer having datatable dt
            var response = customer(dt);
            // Arrange - configure the mock
            mock.Mock<ICustomerService>()
                .Setup(_ => _.GetCustomerDetails(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(response);
            var sut = mock.Create<CustomerViewModel>();
    
            // Act
            var actual = await sut.GetCustomerInfo("12345", "Name");
    
            // Assert - assert on the mock
            mock.Mock<ICustomerService>()
                .Verify(_ => _.GetCustomerDetails(It.IsAny<string>(),It.IsAny<string>(), Times.Once());
            Assert.AreEqual(response, actual);
        }
    }
