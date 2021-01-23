    public static class StructureMapBootstrapper
    {
        public static void Initialize()
        {
            ObjectFactory.Initialize(x =>
            {
                x.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.AssembliesFromApplicationBaseDirectory();
                    scan.AddAllTypesOf(typeof (IRule<>));
                });
                x.For(typeof(IValidator<>))
                    .Use(typeof(GenericValidator<>));
                x.For(typeof(IRuleFactory<>))
                    .Use(typeof(GenericRuleFactory<>));
            });
        }
    }
