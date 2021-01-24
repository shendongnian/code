    container.RegisterInstance<DbContextProvider>(new DbContextProvider
    {
        ActiveDirectryDbContextResolver = () => container.GetInstance<ActiveDirectryContext>(),
        AccountingDbContextResolver = () => container.GetInstance<AccountingContext>()
    });
