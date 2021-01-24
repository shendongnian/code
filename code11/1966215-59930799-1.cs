    [Fact]
    public void ServiceCollection_Lazy_Validation_Mock_Api_Start()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("settings.json", optional: false, reloadOnChange: true);
        _configuration = builder.Build();
        var opt = _configuration.GetSection(nameof(TestOptions)).Get<TestOptions>();
        _serviceCollection.AddConfigWithValidation(_configuration);
        var firstValue = _serviceCollection.BuildServiceProvider().GetRequiredService<IOptionsSnapshot<TestOptions>>().Value;
        firstValue.Should().BeEquivalentTo(opt);
        // edit the json file programmatically, trying to trigger a new IOptionsSnapshot<>
        var path = $"{Directory.GetCurrentDirectory()}\\settings.json";
        var jsonString = File.ReadAllText(path);
        var concreteObject = Newtonsoft.Json.JsonConvert.DeserializeObject<TestObject>(jsonString);
        concreteObject.TestObject.Prop = string.Empty;
        File.WriteAllText(path, Newtonsoft.Json.JsonConvert.SerializeObject(concreteObject));
        _configuration = builder.Build(); // rebuild the config builder
        System.Threading.Thread.Sleep(1000); // let it propagate the change
        // error is thrown, lazy validation is triggered.
        Assert.Throws<OptionsValidationException>(() => _serviceCollection.BuildServiceProvider().GetRequiredService<IOptionsSnapshot<TestOptions>>().Value);
    }
