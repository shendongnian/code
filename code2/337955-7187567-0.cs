    sealed class MyClass : IDisposable
    {
       private FileStream MyManagedResource;
       public void Dispose()
       {
           //this.Dispose(true);
           //GC.SuppressFinalize(this);
           if (MyManagedResource != null)
              MyManagedResource.Dispose();  // this is why we do it all
       }
    }
 
