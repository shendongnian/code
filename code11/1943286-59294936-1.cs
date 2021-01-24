    public class AutofacObjectMappingConventionProvider : IObjectMappingConventionProvider
    {
        public IObjectMappingConvention GetConvention(Type type)
        {
            // here you could filter which type should be instantiated by autofac and return null for other types
            return new AutofacObjectMappingConvention();
        }
    }
