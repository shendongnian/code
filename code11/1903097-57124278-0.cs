    public void checkIfServicesAddedTo_DI() {
        //Arrange
        var services = new ServiceCollection();// Substitute.For<IServiceCollection>();
        var configuration = Substitute.For<IConfiguration>();
        MatchServicesManager servicesManager = new MatchServicesManager();
        //Act
        servicesManager.AddServices(services, configuration);
        //Assert (using FluentAssertions)
        services.Count.Should().Be(1);
        services[0].ServiceType.Should().Be(typeof(IMatchManager));
        services[0].ImplementationType.Should().Be(typeof(MatchManager));
    }
