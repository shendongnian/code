      class Program {  
        static void Main(string[] args) {  
          DbDatabase.DefaultConnectionFactory = new System.Data.Entity.Database.SqlConnectionFactory("Data Source=.;Integrated Security=SSPI");  
          DbDatabase.SetInitializer<StockContext>(new DropCreateDatabaseIfModelChanges<StockContext>());  
          StockContext oContext = new StockContext();  
          oContext.StockOrders.Add(new StockOrder{ StockOrderID = 2, Name = "test"});  
          oContext.SaveChanges();  
        }  
      }  
      public class StockOrder {  
    
        public int StockOrderID { get; set; }  
        public string Name { get; set; }  
      }  
      public class StockContext : DbContext {  
 
        public DbSet<StockOrder> StockOrders { get; set; }  
      }
