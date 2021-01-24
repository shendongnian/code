    public class PaymentDbContext : DbContext
        {
            public PaymentDbContext(DbContextOptions<PaymentDbContext> options)
                : base(options)
            {
    
            }
           
            public DbSet<Payments> Payments { get; set; }    
    
    
        }    
