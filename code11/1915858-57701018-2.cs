        private readonly PaymentDbContext _context;
        
        
         public PaymentsRepository(PaymentDbContext dbContext)
         {
         _context = dbContext;
        }
    
     public DbSet<Payments> Payments { get; set; }
