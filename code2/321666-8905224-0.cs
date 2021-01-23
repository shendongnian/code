    public class Context : DbContext
    {
        public Context()
            : base(new OracleConnection(ConfigurationManager.ConnectionStrings["OraAspNetConString"].ConnectionString), true)
        {
        }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            foreach (var p in typeof(Context).GetProperties().Where(foo=>foo.PropertyType.IsGenericType))
            {
                // this is what we are trying to accomplish here -- 
                //modelBuilder.Entity<User>().ToTable("TBL_USERS", "TestSchema");
                Type tParam = p.PropertyType.GetGenericArguments()[0]; // typeof User
                MethodInfo generic = typeof(DbModelBuilder).GetMethod("Entity").MakeGenericMethod(new[] { tParam });
                object entityTypeConfig = generic.Invoke(modelBuilder, null);
                MethodInfo methodToTable = typeof(EntityTypeConfiguration<>).MakeGenericType(new[] { tParam }).GetMethod("ToTable", new Type[] { typeof(string), typeof(string) });
                methodToTable.Invoke(entityTypeConfig, new[] { GetMappedTableName(tParam), currentOraSchemaName });
            }
            base.OnModelCreating(modelBuilder);
        }
        private string currentOraSchemaName = ConfigurationManager.AppSettings.Get("OraSchemaName");
        private string GetMappedTableName(Type tParam)
        {
            TableAttribute tableAttribute = (TableAttribute)tParam.GetCustomAttributes(typeof(TableAttribute), false).FirstOrDefault();
            return tableAttribute.Name;
        }
    }
