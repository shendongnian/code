    class Order {
     public int ID {get;set;}
     public virtual IList<OrderLine> Lines{get;set;} 
    }
    
    interface IOrderRepository {
      Order GetOrder(id);
      IList<OrderLine> GetOrderLines(Order order);
    }
    
    class OrderService {
    
     IOrderRepository _repository;
    
     public OrderService(IOrderRepository repository) {
      _repository = repository;
     }
    
     public Order GetOrder(int id) {
       return new OrderDecorator(_repository.GetOrder(id));
     }
    }
    
    public class OrderDecorator : Order {
      public OrderDecorator (IOrderRepository repository) {
        _OrderLines = new Lazy<IList<OrderLine>>(()=>repository.GetOrderLines(this));
      }
      
      Lazy<IList<OrderLine>> _OrderLines;
    
      public override IList<OrderLine> Lines {get {return _OrderLines.Value; } set {_OrderLines=new Lazy<IList<OrderLine>>(value);}} 
    }
