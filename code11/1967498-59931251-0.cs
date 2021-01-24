     public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            public DbSet<Employee> Employees { get; set; }
            public DbSet<Attendance> Attendances { get; set; }
            public DbSet<PunchRecord> PunchRecords { get; set; }
        }
