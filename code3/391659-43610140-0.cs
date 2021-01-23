    public partial class StudentDatabaseEntities : DbContext
    {
        public StudentDatabaseEntities()
            : base("name=StudentDatabaseEntities")
        {
            this.Database.CommandTimeout = 180;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<StudentDbTable> StudentDbTables { get; set; }
    }
