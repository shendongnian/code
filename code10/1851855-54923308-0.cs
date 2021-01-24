    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("MyConnectionString") {
        }
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<OvertimeRequest> OvertimeRequests { get; set; }
        public DbSet<HolidayRequest> HolidayRequests { get; set; }
        public DbSet<PaymentRequest> PaymentRequests { get; set; }
    }
