    <#+
    void WriteObjectContextInterface( EntityContainer container, CodeGenerationTools code )
    {
    #>
    /// <summary>
    /// The interface for the generic object context. This contains all of
    /// the <code>ObjectContext</code> properties that are implemented in the 
    /// concrete ObjectContext class. This interface was created so these members
    /// can be mocked, as ObjectContext doesn't have a default public constructor.
    /// </summary>
    <#=Accessibility.ForType(container)#> interface IObjectContext : IDisposable
    {
        void AcceptAllChanges();
        void AddObject(string entitySetName, object entity);
        TEntity ApplyCurrentValues<TEntity>(string entitySetName, TEntity currentEntity) where TEntity : class;
        TEntity ApplyOriginalValues<TEntity>(string entitySetName, TEntity originalEntity) where TEntity : class;
        void ApplyPropertyChanges(string entitySetName, object changed);
        void Attach(System.Data.Objects.DataClasses.IEntityWithKey entity);
        void AttachTo(string entitySetName, object entity);
        int? CommandTimeout { get; set; }
        DbConnection Connection { get; }
        ObjectContextOptions ContextOptions { get; }
        void CreateDatabase();
        string CreateDatabaseScript();
        EntityKey CreateEntityKey(string entitySetName, object entity);
        T CreateObject<T>() where T : class;
        ObjectSet<TEntity> CreateObjectSet<TEntity>() where TEntity : class;
        ObjectSet<TEntity> CreateObjectSet<TEntity>(string entitySetName) where TEntity : class;
        void CreateProxyTypes(IEnumerable<Type> types);
        ObjectQuery<T> CreateQuery<T>(string queryString, params ObjectParameter[] parameters);
        bool DatabaseExists();
        string DefaultContainerName { get; set; }
        void DeleteDatabase();
        void DeleteObject(object entity);
        void Detach(object entity);
        void DetectChanges();
        void Dispose();
        int ExecuteFunction(string functionName, params ObjectParameter[] parameters);
        ObjectResult<TElement> ExecuteFunction<TElement>(string functionName, params ObjectParameter[] parameters);
        ObjectResult<TElement> ExecuteFunction<TElement>(string functionName, MergeOption mergeOption, params ObjectParameter[] parameters);
        int ExecuteStoreCommand(string commandText, params object[] parameters);
        ObjectResult<TElement> ExecuteStoreQuery<TElement>(string commandText, params object[] parameters);
        ObjectResult<TEntity> ExecuteStoreQuery<TEntity>(string commandText, string entitySetName, MergeOption mergeOption, params object[] parameters);
        object GetObjectByKey(System.Data.EntityKey key);
        void LoadProperty(object entity, string navigationProperty);
        void LoadProperty(object entity, string navigationProperty, MergeOption mergeOption);
        void LoadProperty<TEntity>(TEntity entity, Expression<Func<TEntity, object>> selector);
        void LoadProperty<TEntity>(TEntity entity, Expression<Func<TEntity, object>> selector, MergeOption mergeOption);
        System.Data.Metadata.Edm.MetadataWorkspace MetadataWorkspace { get; }
        ObjectStateManager ObjectStateManager { get; }
        void Refresh(RefreshMode refreshMode, IEnumerable collection);
        void Refresh(RefreshMode refreshMode, object entity);
        int SaveChanges();
        int SaveChanges(bool acceptChangesDuringSave);
        int SaveChanges(SaveOptions options);
        ObjectResult<TElement> Translate<TElement>(DbDataReader reader);
        ObjectResult<TEntity> Translate<TEntity>(DbDataReader reader, string entitySetName, MergeOption mergeOption);
        bool TryGetObjectByKey(EntityKey key, out object value);
    }
    <#+
    }
    #>
    
    <#+
    void WriteObjectContextMockBase( EntityContainer container, CodeGenerationTools code )
    {
    #>
    /// <summary>
    /// The default concrete implementation of IObjectContext that will be used for mocking. 
    /// This contains all of the <code>IObjectContext</code> members that are implemented in the 
    /// concrete ObjectContext class. This class was created so these members
    /// can be mocked.
    /// </summary>
    <#=Accessibility.ForType(container)#> abstract class ObjectContextMockBase : IObjectContext
    {
        private readonly IObjectContext _objectContext;
        public ObjectContextMockBase(IObjectContext objectContext)
        {
            if (objectContext == null)
                throw new System.ArgumentNullException("objectContext");
            _objectContext = objectContext;
        }
    
        public virtual void AcceptAllChanges()
        {
            _objectContext.AcceptAllChanges();
        }
        
        public virtual void AddObject(string entitySetName, object entity)
        {
            _objectContext.AddObject(entitySetName, entity);
        }
        
        public virtual TEntity ApplyCurrentValues<TEntity>(string entitySetName, TEntity currentEntity) 
        	where TEntity : class
        {
            return _objectContext.ApplyCurrentValues<TEntity>(entitySetName, currentEntity);
        }
        
        public virtual TEntity ApplyOriginalValues<TEntity>(string entitySetName, TEntity originalEntity) 
        	where TEntity : class
        {
        	return ApplyOriginalValues<TEntity>(entitySetName, originalEntity);
        }
        
        public virtual void ApplyPropertyChanges(string entitySetName, object changed)
        {
            _objectContext.ApplyPropertyChanges(entitySetName, changed);
        }
        
        public virtual void Attach(System.Data.Objects.DataClasses.IEntityWithKey entity)
        {
            _objectContext.Attach(entity);
        }
        
        public virtual void AttachTo(string entitySetName, object entity)
        {
            _objectContext.AttachTo(entitySetName, entity);
        }
        
        public virtual int? CommandTimeout
        {
            get { return _objectContext.CommandTimeout; }
            set { _objectContext.CommandTimeout = value; }
        }
        
        public virtual DbConnection Connection 
        { 
        	get { return _objectContext.Connection; }
        }
        
        public virtual ObjectContextOptions ContextOptions
        { 
        	get { return _objectContext.ContextOptions; }
        }
        
        public virtual void CreateDatabase()
        {
            _objectContext.CreateDatabase();
        }
        
        public virtual string CreateDatabaseScript()
        {
        	return _objectContext.CreateDatabaseScript();
        }
        
        public virtual EntityKey CreateEntityKey(string entitySetName, object entity)
        {
        	return _objectContext.CreateEntityKey(entitySetName, entity);
        }
        
        public virtual T CreateObject<T>() 
        	where T : class
        {
        	return _objectContext.CreateObject<T>();
        }
        
        public virtual ObjectSet<TEntity> CreateObjectSet<TEntity>()
        	where TEntity : class
        {
        	return _objectContext.CreateObjectSet<TEntity>();
        }
        
        public virtual ObjectSet<TEntity> CreateObjectSet<TEntity>(string entitySetName) 
        	where TEntity : class
        {
        	return _objectContext.CreateObjectSet<TEntity>(entitySetName);
        }
        
        public virtual void CreateProxyTypes(IEnumerable<Type> types)
        {
            _objectContext.CreateProxyTypes(types);
        }
        
        public virtual ObjectQuery<T> CreateQuery<T>(string queryString, params ObjectParameter[] parameters)
        {
        	return _objectContext.CreateQuery<T>(queryString, parameters);
        }
        
        public virtual bool DatabaseExists()
        {
        	return _objectContext.DatabaseExists();
        }
        
        public virtual string DefaultContainerName
        {
            get { return _objectContext.DefaultContainerName; }
            set { _objectContext.DefaultContainerName = value; }
        }
        
        public virtual void DeleteDatabase()
        {
            _objectContext.DeleteDatabase();
        }
        
        public virtual void DeleteObject(object entity)
        {
            _objectContext.DeleteObject(entity);
        }
        
        public virtual void Detach(object entity)
        {
            _objectContext.Detach(entity);
        }
        
        public virtual void DetectChanges()
        {
            _objectContext.DetectChanges();
        }
        
        public virtual void Dispose()
        {
            _objectContext.Dispose();
        }
        
        public virtual int ExecuteFunction(string functionName, params ObjectParameter[] parameters)
        {
            return _objectContext.ExecuteFunction(functionName, parameters);
        }
        
        public virtual ObjectResult<TElement> ExecuteFunction<TElement>(string functionName, params ObjectParameter[] parameters)
        {
        	return _objectContext.ExecuteFunction<TElement>(functionName, parameters);
        }
        
        public virtual ObjectResult<TElement> ExecuteFunction<TElement>(string functionName, MergeOption mergeOption, params ObjectParameter[] parameters)
        {
        	return _objectContext.ExecuteFunction<TElement>(functionName, mergeOption, parameters);
        }
        
        public virtual int ExecuteStoreCommand(string commandText, params object[] parameters)
        {
            return _objectContext.ExecuteStoreCommand(commandText, parameters);
        }
        
        public virtual ObjectResult<TElement> ExecuteStoreQuery<TElement>(string commandText, params object[] parameters)
        {
        	return _objectContext.ExecuteStoreQuery<TElement>(commandText, parameters);
        }
        
        public virtual ObjectResult<TEntity> ExecuteStoreQuery<TEntity>(string commandText, string entitySetName, MergeOption mergeOption, params object[] parameters)
        {
        	return _objectContext.ExecuteStoreQuery<TEntity>(commandText, entitySetName, mergeOption, parameters);
        }
        
        public virtual object GetObjectByKey(EntityKey key)
        {
        	return _objectContext.GetObjectByKey(key);
        }
        
        public virtual void LoadProperty(object entity, string navigationProperty)
        {
            _objectContext.LoadProperty(entity, navigationProperty);
        }
        
        public virtual void LoadProperty(object entity, string navigationProperty, MergeOption mergeOption)
        {
            _objectContext.LoadProperty(entity, navigationProperty, mergeOption);
        }
        
        public virtual void LoadProperty<TEntity>(TEntity entity, Expression<Func<TEntity, object>> selector)
        {
            _objectContext.LoadProperty<TEntity>(entity, selector);
        }
        
        public virtual void LoadProperty<TEntity>(TEntity entity, Expression<Func<TEntity, object>> selector, MergeOption mergeOption)
        {
            _objectContext.LoadProperty<TEntity>(entity, selector, mergeOption);
        }
        
        public virtual System.Data.Metadata.Edm.MetadataWorkspace MetadataWorkspace
        {
        	get { return _objectContext.MetadataWorkspace; }
        }
        
        public virtual ObjectStateManager ObjectStateManager
        {
        	get { return _objectContext.ObjectStateManager; }
        }
        
        public virtual void Refresh(RefreshMode refreshMode, IEnumerable collection)
        {
            _objectContext.Refresh(refreshMode, collection);
        }
        
        public virtual void Refresh(RefreshMode refreshMode, object entity)
        {
            _objectContext.Refresh(refreshMode, entity);
        }
        
        public virtual int SaveChanges()
        {
        	return _objectContext.SaveChanges();
        }
        
        public virtual int SaveChanges(bool acceptChangesDuringSave)
        {
        	return _objectContext.SaveChanges(acceptChangesDuringSave);
        }
        
        public virtual int SaveChanges(SaveOptions options)
        {
        	return _objectContext.SaveChanges(options);
        }
        
        public virtual ObjectResult<TElement> Translate<TElement>(DbDataReader reader)
        {
        	return _objectContext.Translate<TElement>(reader);
        }
        
        public virtual ObjectResult<TEntity> Translate<TEntity>(DbDataReader reader, string entitySetName, MergeOption mergeOption)
        {
        	return _objectContext.Translate<TEntity>(reader, entitySetName, mergeOption);
        }
        
        public virtual bool TryGetObjectByKey(EntityKey key, out object value)
        {
            return _objectContext.TryGetObjectByKey(key, out value);
        }
    }
    <#+
    }
    #>
	
