    class Parent : IDisposable 
    {
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    //dispose managed resources
                }
            }
            //dispose unmanaged resources
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
                    //dispose managed resources
                }
                base.Dispose(disposing);
            }
            //dispose unmanaged resources
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
