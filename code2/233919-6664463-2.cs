    using System.Data.Entity.ModelConfiguration;
    public class Processor
    {
        public int ProcessorId { get; set; }
        public byte[] ProcessorDLL { get; set; }
    }
    public class ProcessorConfiguration : EntityTypeConfiguration<Processor>
    {
        public ProcessorConfiguration()
        {
            HasKey(i => i.ProcessorId);
            ToTable("Processor", "dbo");
        }
    }
    //DbContext
    public class myContext : DbContext
    {
        public DbSet<Processor> Processors { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProcessorConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
