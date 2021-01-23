    public class MyProductQueryResult
    {
      public int ProductId {get;set;}
      public DateTime? DateAvailable {get;set;}
    }
    
    from p in entities.Products 
    from paj in p.ProductAvailabilities.DefaultIfEmpty()
    select new MyProductQueryResult()
      {ProductId = p.ProductId, DateAvailable = paj.DateAvailable}
