    class RefStruct : IDisposable
    {
       public object token;
       public object item;
       
       public void Dispose() 
       { 
           Dispose(true);
           GC.SuppressFinalize(this);
       }
       protected virtual void Dispose(bool disposing)
       {
            if (disposing)
            {
                token = null; // not necessary technically
            }
        }
    }
