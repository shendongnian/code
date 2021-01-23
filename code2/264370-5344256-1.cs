    public void Bla<T>() where T:class
    {
    UnityContainer.RegisterType<Func<IDataContextAdapter, IRepository<T>>>(
        new InjectionFactory(c => 
                        new Func<IDataContextAdapter, IRepository<T>>(
                            context => new Repository<T>(context))
            )
     );
    }
