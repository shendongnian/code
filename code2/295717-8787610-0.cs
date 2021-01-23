    private IStoreEvents GetInitializedEventStore(IDispatchCommits bus)
        {
            return Wireup.Init()
                .UsingRavenPersistence(BootStrapper.RavenDbEventStoreConnectionStringName)
                .UsingAsynchronousDispatchScheduler(bus)
                .Build();
        }
