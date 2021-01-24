    public class MyRepositoryProvider : IProvider {
        private ApplicationDbContext _applicationDbContext;
    
        public MyRepositoryProvider(ApplicationDbContext applicationDbContext) {
            _applicationDbContext = applicationDbContext;
        }
    
        Type Type => typeof(MyRepository<>);
    
        public object Create(IContext context) {
            var genericArguments = context.GenericArguments; //TEntity
            var genericType = this.Type.MakeGenericType(genericArguments); //MyRepository<TEntity>
            
            //using reflection to do new MyRepository<TEntity>(_applicationDbContext)
            return Activator.CreateInstance(genericType, _applicationDbContext);
        }
    }
