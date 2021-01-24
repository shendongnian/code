    //Arrange
    Dictionary<string, string> inMemorySettings =
        new Dictionary<string, string> {
            {"a", "0.01"},
            {"b:0", "xxx"},
            {"b:1", "yyy"}
        };
    IConfiguration configuration = new ConfigurationBuilder()
        .AddInMemoryCollection(inMemorySettings)
        .Build();
    //Verify expected configuraton
    configuration.GetSection("a").Get<double>().Should().Be(0.01d);
    configuration.GetSection("b").Get<List<string>>().Should().NotBeEmpty();
    //...
