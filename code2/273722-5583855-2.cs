    using MethodHandlers;  // contains the two method handlers
    public class ServiceA : IServiceA
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
       
       public void Method_X1()
       {
           // handle method X1 call here or delegate to another handler class
       }
    }
