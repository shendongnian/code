    public IDbContext CreateDbContext<TDbContext>() where TDbContext : IDbContext
    {
       var key = typeof(TDbContext).ToString();
       // This is wrong because it is trying to resolve AuthenticationContext for a given name.
       // But it should resolve a registration for IDbContext for that name since that is
       // how it was registered!
       // return container.Resolve<TDbContext>(key);
       return container.Resolve<IDbContext>(key);
    }
