    public interface IRequest
    {
    
    }
    
    public interface IMediator
    {
        TResponse Send<TRequest, TResponse>(IRequest request);
    }
    
    public class MyRequest : IRequest
    {
    }
    
    public class MyResponse
    {
    }
    
    public class Mediator : IMediator
    {
        public TResponse Send<TRequest, TResponse>(IRequest request)
        {
            Console.WriteLine("Processing...");
            return default(TResponse);
        }
    }  
