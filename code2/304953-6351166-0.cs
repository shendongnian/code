    public abstract class HandlerBase<T> where T: Request
    {
        public abstract T Request {get;set;}
    }
    
    public class Handler: HandlerBase<Request>()
    
    public class DerivedHandler: HandlerBase<DerivedRequest>()
