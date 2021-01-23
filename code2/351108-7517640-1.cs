    class MyObj
    {
       SynchronizationContext _context;
       public MyObj()
       {
         _context = SynchronizationContext.Current;
       }
    
       public void MyInvoke(Action a)
       {
           _context.Post((SendOrPostCallback)(_ => a()), null);
       }
    }
