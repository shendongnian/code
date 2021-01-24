    [Testcase("data")]
    public async Task CanGetById(string value) {
        //Arrange
        var model = new SomeModel { Name = value };
        var dependency = new Mock<IDependency>();
        dependency
            .Setup(x => x.GetByIdAsync(value))
            .ReturnsAsync(model)
            .Verifiable(); 
        var service = new SomeService(dependency.Object);
        //Act
        var clone = await service.GetByIdAsync(value);
        //Assert
        dependency.Verify();
    }
