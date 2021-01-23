    using MethodHandlers;  // contains the two method handlers
    public class ServiceB : IServiceB
    {
       public void Method_A()
       {
           MethodAHandler hnd = new MethodAHandler();
           hnd.HandleMethodCall();
       }
       
       public void Method_B()
       {
           MethodBHandler hnd = new MethodBHandler();
           hnd.HandleMethodCall();
       }
       
       public void Method_X2()
       {
           // handle method X2 call here or delegate to another handler class
       }
    }
