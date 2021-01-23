    public class Part
    { 
        public string PartNumber
        {
            get
            {
                return this.PartId ?? this.ChildPartId;
            }  
        }
        internal string PartId { get; set; }
        internal string ChildPartId { get; set; }
    }
    public class PartsContext : DbContext
    { 
        public DbSet<Part> Parts { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Part>().Ignore(e => e.PartNumber);   
            base.OnModelCreating(modelBuilder);
        }
    }
