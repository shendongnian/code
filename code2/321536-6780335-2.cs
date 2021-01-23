    namespace YourAppNamespace.Website.IoC
    {
        public static class SmIoC
        {
            public static IContainer Initialize()
            {
                ObjectFactory.Initialize(x =>
                            {
                                x.For<IProjectRepository>().Use<ProjectRepository>();
                                //etc...
                            });
    
                return ObjectFactory.Container;
            }
        }
    }
