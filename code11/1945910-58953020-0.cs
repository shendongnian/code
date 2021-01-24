    services.AddTransient<CacheModeTypes>(sp => {
         if(someCriteria) 
            return CacheModeTypes.Default; 
        else 
            return CacheModeTypes.NoCache;        
    });
    services.AddSingleton(typeof(ICacheProvider<,>), typeof(CacheProvider<,>));
