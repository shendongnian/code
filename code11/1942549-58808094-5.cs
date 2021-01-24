    [Test]
    public void LogicABC_Query1_Should_Return_One_Id() {
        //Arrange
        int expected = 123456789;
        var items = new [] { new C { Id = expectedId } }
    
        Mock<IRepositoryC> mock = new Mock<IRepositoryC>();
        mock.Setup(_ => _.GetAll()).Returns(items);
        
        LogicABC logic = new LogicABC(null, null, mock.Object);
        
        //Act
        List<int> list = logic.Query1();
        
        //Assert
        
        mock.Verify(_ => _.GetAll(), Times.Once());
        //checking expected behavior - using FluentAssertions
        list.Should().HaveCount(1);
        
        int actual = list.First();
        
        actual.Should().Be(expected); // using FluentAssertions
    }
