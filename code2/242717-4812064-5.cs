    public class OrderDecorator : Order {
      public OrderDecorator (IOrderRepository repository) {
        _Repo = repository;
      }
      IOrderRepository _Repo;
    
      public override IList<OrderLine> Lines {
       get {
         if (base.OrderLines == null)
           base.OrderLines = repository.GetOrderLines(this);
         return base.OrderLines; 
       } 
       set {base.OrderLines=value;}
     }
    }
