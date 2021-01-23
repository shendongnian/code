    Model.Entities entities = new Model.Entities();
    
            public ServicePeople()
            {
                entities.ContextOptions.ProxyCreationEnabled = false;
                entities.ContextOptions.LazyLoadingEnabled = false;
            }
