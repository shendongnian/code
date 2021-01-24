    [Fact]
    public void MyFilterTest()
    {
        IServiceCollection services = new ServiceCollection();
        services.AddScoped<IDependency, MyDependency>();
        var httpContext = await SimulateRequest(services, "Ping");
        Assert.Equal(403, httpContext.Response.StatusCode);
    }
