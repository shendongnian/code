    protected override IKernel CreateKernel()
    {
       return new StandardKernel(new NinjectRepositoryModule(),
                                 new NinjectAggregateServiceModule());
    }
