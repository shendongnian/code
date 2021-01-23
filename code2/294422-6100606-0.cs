    class Program
    {
    
        static void Main(string[] args)
        {
            Database.SetInitializer(new CustomInitializer());
            using (var context = new Context())
            {
                context.TestEntities.Add(new TestEntity() { Name = "A" });
                context.TestEntities.Add(new TestEntity() { Name = "B" });
                context.SaveChanges();
            }
        }
    }
    public class CustomInitializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            base.Seed(context);
            context.Database.ExecuteSqlCommand(@"
                DECLARE @Name VARCHAR(100)
                SELECT @Name = O.Name FROM sys.objects AS O
                INNER JOIN sys.tables AS T ON O.parent_object_id = T.object_id
                WHERE O.type_desc LIKE 'DEFAULT_CONSTRAINT' 
                  AND O.Name LIKE 'DF__TestEntities__Id__%'
                  AND T.Name = 'TestEntities'
                DECLARE @Sql NVARCHAR(2000) = 'ALTER TABLE TestEntities DROP Constraint ' + @Name
                EXEC sp_executesql @Sql
                ALTER TABLE TestEntities
                ADD CONSTRAINT IdDef DEFAULT NEWSEQUENTIALID() FOR Id");
        }
    }
    public class TestEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public class Context : DbContext
    {
        public DbSet<TestEntity> TestEntities { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TestEntity>()
                .Property(e => e.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
