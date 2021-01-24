    [Test]
    public void GetComponent_GivenComponentFactory_ExpectBoardComponent() {
        //Arrange
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddScoped<BoardItemComponent>();
        serviceCollection.AddScoped<IConfigurationRepository>(sp => Mock.Of<IConfigurationRepository>());
        
        var factory = new DiagnosticsComponentFactory(serviceCollection.BuildServiceProvider());
        //Act
        var component = factory.Create(BoardItemComponent.TypeName);
        //Assert
        Assert.IsNotNull(component);
    }
