    namespace Nop.Plugin.MostViewed
    {
      public class MostViewObjectContext: DbContext, IDbContext
      {
        public MostViewObjectContext(string nameOrConnectionString) : base(nameOrConnectionString) { }
      protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
         Database.SetInitializer<MostViewObjectContext>(null);
         modelBuilder.Configurations.Add(new YourTableMappingClass());
        }
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }
        public IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters) where TEntity : BaseEntity, new()
        {
            throw new NotImplementedException();
        }
         public string CreateDatabaseScript()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateDatabaseScript();
        }
        //Other all methods like  Install() and Uninstall()
      }
    }
