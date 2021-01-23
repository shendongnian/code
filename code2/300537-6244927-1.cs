    public class Context : DbContext
    {
        public DbSet<JobStatusSearchTypeTable> JobStatuses { get; set; }
        public DbSet<BooleanSearchTypeTable> BooleanStatuses { get; set; }
        public DbSet<PersonStatusSearchTypeTable> PersonStatuses { get; set; }
    }
