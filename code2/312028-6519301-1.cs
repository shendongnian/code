    public void Dispose() //Implementes the IDisposable interface
    { 
        this.Dispose(true);
        GC.SupressFinalize(this); //All resources have been released, no need to run the finalizer. We make the GC's life a little easier;
    } 
    protected void Dispose(bool disposing)
    {
         if (disposing)
         {
            //Relesase managed resources.
         }
        
        //Release unmanaged resources.
    }
    ~MyDisposableObject()  //finalizer
    {
        this.Dispose(false)
    }
