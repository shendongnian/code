    public class Request{}
    
    public class DerivedRequest : Request{}
    
    public class Handler<T>
      where T : Request
    {
      public abstract T Request { get; set; }
    }
    
    public class DerivedHandler : Handler<DerivedRequest>
    {
      public override DerivedRequest Request { get; set; }
    }
