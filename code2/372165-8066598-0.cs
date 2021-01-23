    public partial class MyEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initialize a new MyEntities object.
        /// </summary>
        public MyEntities(string connectionString) : base(connectionString, "MyEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new MyEntities object.
        /// </summary>
        public MyEntities(EntityConnection connection) : base(connection, "MyEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    #endregion
    ....
