    ObjectFactory.Initialize(x =>
            {
                x.For<IUnitOfWorkFactory>().Use<EFUnitOfWorkFactory>();
                x.For<IDalFactory>().Use<DalFactory>();
            }
        );
