    public class SetupSM
        {
            public void Setup()
            {
                ObjectFactory.Configure(config =>
                { 
                    config.Scan(scan =>
                    {
                        scan.TheCallingAssembly();
                        scan.WithDefaultConventions();
                    });
                    config.For<ISomething>().Use<SomeThingOne>();
                });
        }
