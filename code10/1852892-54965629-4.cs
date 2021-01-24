    public class DataDbContext : DbContext
    {
        public string ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True;";
        public object myclass;  // define the class outside of the OnModelCreating override
        public DataDbContext()
        {   // create the class in the consrtuctor 
            MyClassBuilder MCB = new MyClassBuilder("Student");
            var type_array = new Type[3] { typeof(int), typeof(string), typeof(string) };
            myclass = MCB.CreateObject(new string[3] { "ID", "Name", "Address" }, type_array);
            Type type = myclass.GetType();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { optionsBuilder.UseSqlServer(ConnectionString); }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Type type = myclass.GetType();
            var entityMethod = typeof(ModelBuilder).GetMethod("Entity", new Type[] { });
            if (type.IsClass)
            { entityMethod.MakeGenericMethod(type).Invoke(modelBuilder, new object[] { }); }
            base.OnModelCreating(modelBuilder);
        }
    }
