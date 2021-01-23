    class MyClass : IDisposable
    {
       private bool _Disposed;
       private SomeHelper _Helper;
       protected virtual void Dispose()
       {
          this.Dispose(true);
       }
       public void Dispose(bool disposing)
       {
         if (_!Disposed && disposing)
         {
           if (_Helper != null)
              _Helper.Dispose();
           _Disposed = true;
         }
       }
    }
