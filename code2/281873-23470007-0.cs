    public class MyDisposableList<T> : List<T> : IDisposable
    {
        private bool disposed = false;
        
        ~MyDisposableList()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
        }
        protected void Dispose(bool disposing)
        {
            if (!disposed)
            {
                foreach (T myT in this)
                {
                    IDisposable myDisposableT = myT as IDisposable;
                    if (myDisposableT != null)
                    {
                        myDisposableT.Dispose();
                    }
                    myT = null;
                }
                this.Clear();
                this.TrimExcess();
                disposed = true;
            }
        }
        ...
    }
