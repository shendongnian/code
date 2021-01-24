    class Center
    {
        public int Id {get; set;}
        ...
        // every Center offers zero or more facilities (many-to-many)
        public virtual ICollection<Factility> Facilities {get; set;}
    }
    class Facility
    {
        public int Id {get; set;}
        ...
        // every Facility is offered at zero or more Centers (many-to-many)
        public virtual ICollection<Center> Centers {get; set;}
    }
    class MyDbContext : DbContext
    {
        public DbSet<Center> Centers {get; set;}
        public DbSet<Facility> Facilities {get; set;}
    }
