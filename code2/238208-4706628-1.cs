    public class User 
    {
        public int UserId { get; set; }
    }
    public abstract class FruitBase
    {
        public int Id { get; set; }
        public int CreateById { get; set; }
        [ForeignKey("CreateById")]
        public User CreateBy { get; set; }
    }
    public class Banana : FruitBase { }
                        
    public class DataContext : DbContext
    {        
        public DbSet<FruitBase> Fruits { get; set; }                
    }
