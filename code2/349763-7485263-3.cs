    class Parent : IDisposable 
    {
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    //dispose managed ressources
                }
            }
            //dispose unmanaged ressources
            disposed = true;
        }
    }
    class Child : Parent, IDisposable 
    { 
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    base.Dispose(disposing);
                }
            }
            //dispose unmanaged ressources
            disposed = true;
        }
    }
    class Owner:IDisposable
    {
        Child child = new Child();
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if(child!=null)
                    {
                        child.Dispose();
                    }
                }
            }
            //dispose unmanaged ressources
            disposed = true;
        }
    }
