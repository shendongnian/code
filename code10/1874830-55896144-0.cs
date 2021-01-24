    [Theory]
    [InlineData(typeof(IDataStorage))]
    [InlineData(typeof(ILogger))]
    [InlineData(typeof(DiscordSocketClient))]
    [InlineData(typeof(Connection))]
    public void Resolve_Singleton_Services_ShouldWork(Type type) {
        //Arrange
        var unityType = typeof(Unity);
        var resolve = unityType.GetMethod("Resolve", BindingFlags.Static| BindingFlags.Public);
        var genericResolve = resolve?.MakeGenericMethod(type);
        //Act
        var instance1 = genericResolve.Invoke(null,null);
        var instance2 = genericResolve.Invoke(null, null);
        //Assert
        Assert.NotNull(instance1);
        Assert.NotNull(instance2);
        Assert.Same(instance1, instance2);
    }
