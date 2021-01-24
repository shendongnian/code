        AssertResolvedTypesAreSame<IDataStorage>();
        AssertResolvedTypesAreSame<ILogger>();
        AssertResolvedTypesAreSame<DiscordSocketClient>();
        AssertResolvedTypesAreSame<Connection>();
    }
    
    private void AssertResolvedTypesAreSame<T>()
    {
        var t1 = Unity.Resolve<T>(); 
        var t2 = Unity.Resolve<T>();
    
        Assert.NotNull(t1); 
        Assert.NotNull(t2); 
        Assert.Same(t1, t2); 
    }
