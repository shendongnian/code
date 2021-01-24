    [Fact]
    public void MyTest() {
        //Arrange
        var services = new ServiceCollection();
        services.AddOptions();
        
        IConfiguration config = new ConfigurationBuilder()
            // Call additional providers here as needed.
            //...
            .Build();
        
        //Act
        MyServicesBuilder.AddMyServices(services, config);
        //OR
        //services.AddMyServices(config);
        
        //Assert
        var serviceProvider = services.BuildServiceProvider();
        var razorOptions = serviceProvider.GetService<IOptions<RazorViewEngineOptions>>();
        Assert.NotNull(razorOptions);
        Assert.Equal(1, razorOptions.Value.FileProviders.Where(x => x.GetType() == typeof(EmbeddedFileProvider)).Count());
    }
