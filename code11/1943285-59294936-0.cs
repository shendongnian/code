    public class AutofacObjectMappingConvention : IObjectMappingConvention
    {
        private readonly IComponentContext _container;
    
        public AutofacObjectMappingConvention(IComponentContext context)
        {
            _container = context ?? throw new ArgumentNullException(nameof(context));
        }
    
    
        public void Apply<T>(JsonSerializerOptions options, ObjectMapping<T> objectMapping) where T : class
        {
            defaultObjectMappingConvention.Apply<T>(options, objectMapping);
            
            // use Autofac to create types that have been registered with it
            if (_container.IsRegistered(objectType))
            {
                objectMapping.MapCreator(o => _container.Resolve<T>());
            }
        }
    }
