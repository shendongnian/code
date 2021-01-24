    [Fact]
    public void Test()
    {
        var provider = new ServiceCollection()
            .AddTransient(typeof(IValidator<Command>), typeof(OrderValidator))
            .AddTransient(typeof(IValidator<Command>), typeof(CommandValidator))
            .BuildServiceProvider();
    
        var validators = provider.GetServices<IValidator<Command>>();
    
        validators.Should().HaveCount(2);
    }
