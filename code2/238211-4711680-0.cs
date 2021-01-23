    class User{}
    
    abstract class AuditObjectBase{ // was FruitBase
    
       // [ForeignKey("CreateById")]
       public abstract User CreateBy{ get; set; } // made abstract
    
       public int CreateById{ get; set; }
    
    }
    
    class ItemOne : AuditObjectBase{ // Was Banana
    
       // added
       [ForeignKey("CreateById")]
       public override User CreateBy{ get; set; }
    }
    class ItemTwo : AuditObjectBase{ // Added
    
       [ForeignKey("CreateById")]
       public override User CreateBy{ get; set; }
    }
    
    class DataContext : DbContext{
    
       DbSet<ItemOne> ItemOnes{ get; set; }
       DbSet<ItemTwo> ItemTwos{ get; set; }
    }
