    public class ProjectContext: DbContext
    {
        public ProjectContext()
        {
        }
        public Client Client { get; set; }
        public Job Job { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new JobConfig());
        }
     }
