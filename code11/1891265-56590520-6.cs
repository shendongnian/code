            // Composition Root
            var container = new UnityContainer();
            container.RegisterFactory<IMetric>(c => BuildMetric());
            container.RegisterType<ILoader, Loader>();
            container.RegisterType<ISomeClassThatDependsOnLoader, SomeClassThatDependsOnLoader>();
