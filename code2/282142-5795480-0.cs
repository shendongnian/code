    // Base repository class for entity with any complex key
    public abstract class RepositoryBase<TEntity> where TEntity : class
    {
        private readonly string _entitySetName;
        private readonly string[] _keyNames;
        protected ObjectContext Context { get; private set; }
        protected ObjectSet<TEntity> ObjectSet { get; private set; }
        protected RepositoryBase(ObjectContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            Context = context;
            ObjectSet = context.CreateObjectSet<TEntity>();
            // Get entity set for current entity type
            var entitySet = ObjectSet.EntitySet;
            // Build full name of entity set for current entity type
            _entitySetName = context.DefaultContainerName + "." + entitySet.Name;
            // Get name of the entity's key properties
            _keyNames = entitySet.ElementType.KeyMembers.Select(k => k.Name).ToArray();
        }
        public virtual TEntity GetByKey(params object[] keys)
        {
            if (keys.Length != _keyNames.Length)
            {
                throw new ArgumentException("Invalid number of key members");
            }
            // Merge key names and values by its order in array
            var keyPairs = _keyNames.Zip(keys, (keyName, keyValue) => 
                new KeyValuePair<string, object>(keyName, keyValue));
            // Build entity key
            var entityKey = new EntityKey(_entitySetName, keyPairs);
            // Query first current state manager and if entity is not found query database!!!
            return (TEntity)Context.GetObjectByKey(entityKey);
        }
        // Rest of repository implementation
    }
