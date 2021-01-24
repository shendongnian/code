    public class MyImpl : IMyInterface
    {
    }
    
    public class MyController : Controller, IMyInterface
    {
         private readonly IMyInterface _inner; //delegate implementation to this one.
         public MyController(IMyInterface inner)
         {
             _inner = inner;
         }
    }
