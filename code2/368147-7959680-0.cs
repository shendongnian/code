    public class MyClass
    {
      private bool _isInitialized;
    
      public MyClass()
      {
        ... only basic initializations...
      }
    
      private void initialize()
      {
        if (_isInitialized)
          return;
    
        // initialize here
      }
    
      public void SimpleMethod()
      {
        // doesn't need to initialize
      }
    
      public void ComplexMethod()
      {
        initialize();
    
        // do something...
      }
    }
