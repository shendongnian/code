    container.Register<ActiveDirectryContext>(Lifestyle.Scoped);
    container.Register<AccountingContext>(Lifestyle.Scoped);
    container.RegisterInstance<DbContextProvider>(new DbContextProvider
    {
        ActiveDirectryDbContextResolver = () => container.GetInstance<ActiveDirectryContext>(),
        AccountingDbContextResolver = () => container.GetInstance<AccountingContext>()
    });
