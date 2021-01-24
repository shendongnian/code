    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
    }
    public class Appointment : Event
    {
        public TimeSpan Duration { get; set; }
    }
    public class ApplicationDbContext : DbContext
    {
        ...
        public DbSet<Event> Events { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ...
            modelBuilder.Entity<Event>()
                .HasDiscriminator<int>("discriminator")
                .HasValue<Event>(1)
                .HasValue<Appointment>(2);
        }
    }
