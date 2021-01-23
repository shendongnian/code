        public class AClass : IDisposable 
        {
        public void Dispose() 
        {
            Dispose(true);
            GC.SuppressFinalize(this); 
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing) 
            {
	        // Free managed objects.
            }
            // Free unmanaged objects.
        }
        ~AClass() 
        {
	     // Simply call Dispose(false).
             Dispose (false);
        }
    }
