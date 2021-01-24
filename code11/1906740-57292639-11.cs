    public class GameContext : DbContext
    {
        public GameContext() { }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Pick> Picks { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=Sandbox;Trusted_Connection=True;ConnectRetryCount=0");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pick>(entity =>
            {
                entity.HasOne(x => x.Employee)
                    .WithMany(x => x.Picks)
                    .HasForeignKey(x => x.EmployeeId);
                entity.HasOne(x => x.TeamChoice)
                    .WithMany(x => x.Picks)
                    .HasForeignKey(x => x.TeamChoiceId);
                entity.HasOne(x => x.Schedule)
                    .WithMany(x => x.Picks)
                    .HasForeignKey(x => x.ScheduleId);
            });
        }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public ICollection<Pick> Picks { get; set; }
    }
    public class Schedule
    {
        public int Id { get; set; }
        public int? GameTotal { get; set; }
        public ICollection<Pick> Picks { get; set; }
    }
    public class Team
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public ICollection<Pick> Picks { get; set; }
    }
    public class Pick
    {
        public int Id { get; set; }
        public virtual Schedule Schedule { get; set; }
        public int ScheduleId { get; set; }
        public virtual Team TeamChoice { get; set; }
        public int TeamChoiceId { get; set; }
        public int? TieBreakerScore { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual int EmployeeId { get; set; }
        public DateTime LastUpdated { get; set; }
    }
