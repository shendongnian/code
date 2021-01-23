    [Table(...)]
    public class MyTableClass
    {
      [Column(...)]
      int RelatesToColumn{get;set;}
      
      int DoesntRelateToColumn
      {
        get { return RelatesToColumn + 42; }
      }
    }
