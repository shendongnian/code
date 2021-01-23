    public class OrderDecorator : Order {
      public OrderDecorator (IOrderRepository repository) {
        _Repo = repository;
      }
      IOrderRepository _Repo;
      IList<OrderLine> _OrderLines = null;
    
      public override IList<OrderLine> Lines {
       get {
         if (_OrderLines == null)
           _OrderLines = repository.GetOrderLines(this);
         return _OrderLines; 
       } 
       set {_OrderLines=value;}
     }
    }
