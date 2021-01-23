    // Handler.cs
    public class Handler<TRequest> where TRequest : Request
    {
        public TRequest Request { get; set; }
    }
    
    // DerivedHandler.cs
    public class DerivedHandler : Handler<DerivedRequest>
    {
    }
