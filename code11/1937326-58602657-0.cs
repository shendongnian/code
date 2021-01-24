    public class Model
    {
        public long ModelId { get; set; }
        [NotMapped]
        public string ModelIdString
        {
            get { return ModelId.ToString(); }
        }
        public decimal ModelValue { get; set; }
    }
    public class ModelContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //configure column names
            modelBuilder.Entity<Model>().ToTable("db_model", "user_dba");
            modelBuilder.Entity<Model>(p =>
            {
                p.Property(md => md.ModelId).HasColumnName("model_id");
                p.Property(md => md.ModelValue).HasColumnName("value");
            });
        }
    }
