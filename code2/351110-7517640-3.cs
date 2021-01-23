    class MyObj
    {
       SynchronizationContext _context;
       // please Note: construct the Objects in your main/ui thread to caputure the
       // right context
       public MyObj()
       {
         CaptureCurrentContext();
       }
       // or call this from your main/UI thread
       public void CaptureCurrentContext()
       {
          _context = SynchronizationContext.Current;
       }
    
       public void MyInvoke(Action a)
       {
           _context.Post((SendOrPostCallback)(_ => a()), null);
       }
    }
