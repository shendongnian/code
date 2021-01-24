        public class DatabaseContext : DbContext
        {
              public DbSet<User> Users { get; set; }
              public DbSet<OvertimeRequest> OvertimeRequests { get; set; }
              public DbSet<HolidayRequest> HolidayRequests { get; set; }
              public DbSet<PaymentRequest> PaymentRequests { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseSqlServer(Setting.ConnectionString);
                }
            }
        }
