    public class HasUnmanagedResource : IDisposable
    {
      IntPtr _someRawHandle;
      /* real code using _someRawHandle*/
      private void CleanUp()
      {
         /* code to clean up the handle */
      }
      public void Dispose()
      {
         CleanUp();
         GC.SuppressFinalize(this);
      }
      ~HasUnmanagedResource()
      {
         CleanUp();
      }
    }
