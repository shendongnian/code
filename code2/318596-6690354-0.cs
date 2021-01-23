    class MainClass : IDisposable
    {
       private OtherClass1;
       MainClass()
       {
          OtherClass1 = new OtherClass1();
       }
    
       public void Dispose()
       {
          OtherClass1.Dispose(); 
          // OtherClass1 = null;  // not needed
       }
    }
