    public partial class FooEntities : DbContext
    {
       public FooEntities()
             : base("name=FooEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
          // Get the ObjectContext related to this DbContext
            var objectContext = (this as IObjectContextAdapter).ObjectContext;
            // Sets the command timeout for all the commands
            objectContext.CommandTimeout = 380;
        }
