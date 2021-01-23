    public class BaseRepository<T> where T : class 
    {
        public static ManagerDbContext baseContext;
        public BaseRepository() { }
        public BaseRepository(ManagerDbContext context)
        {
            baseContext = context;
        }
        private static object _entity;
        public void AttachEntity(object entity)
        {
            _entity = entity;
            entityAttachFunctions[entity.GetType().BaseType]();
        }
        private Dictionary<Type, Func<bool>> entityAttachFunctions = new Dictionary<Type, Func<bool>>()
        {
            {typeof(User), () => AttachUser()},
            {typeof(Application), () => AttachApplication()}
        };
        private static bool AttachUser()
        {
            ((IObjectContextAdapter)baseContext).ObjectContext.AttachTo(User.TableName, _entity);
            return true;
        }
        private static bool AttachApplication()
        {
            ((IObjectContextAdapter)baseContext).ObjectContext.AttachTo(Application.TableName, _entity);
            return true;
        }
    }
