        class Program
        {
            static void Main(string[] args)
            {
                PMSCatalogEntities entities = new PMSCatalogEntities();
    
                Subscription subs = new Subscription();
                subs.Id = Guid.NewGuid();
                subs.Date = DateTime.Now;
                subs.PaymentId = 1;
    
                entities.Subscriptions.Add(subs);
                entities.SaveChanges();
            }
        }
    
        public class PMSCatalogEntities : DbContext
        {
            public DbSet<Subscription> Subscriptions { get; set; }
    
            public DbSet<Payment> Payments { get; set; }
    
        }
        
        public class Subscription
        {
            public Guid Id { get; set; }
    
            public DateTime Date { get; set; }
    
            public Payment Payment { get; set; }
    
            public int PaymentId { get; set; }
        }
    
        public class Payment
        {
            public int Id { get; set; }
    
            public string Type { get; set; }
        }
