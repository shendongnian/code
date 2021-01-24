        [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
     ConcurrencyMode = ConcurrencyMode.Multiple)]
    class MyService : IMyContract
    {
     public void MyMethod()
     {
     lock(typeof(MyService))
     {
     ...
     MyResource.DoWork();
     ...
     }
     }
    }
    static class MyResource
    {
     public static void DoWork()
     {
     lock(typeof(MyService))
     {
     ...
     }
     }
    }
