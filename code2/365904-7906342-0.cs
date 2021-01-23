    public class DisposableBase : IDisposable
    {
      private bool mDisposed;
      ~DisposableBase()
      {
          if (!mDisposed)
             System.Diagnostics.Debug.WriteLine ("Object not disposed: " + this + "(" + GetHashCode() + ")";
          Dispose(false);
      }
  
      public void Dispose()
      {
          Dispose(true);
          GC.SuppressFinalize(this);
      }
