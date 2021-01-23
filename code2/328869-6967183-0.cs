    class Foo : IDisposable
    {
        private bool m_disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~Foo()
        {
            Dispose(false);
        }
        protected void Dispose(bool disposing)
        {
            if (!m_disposed)
            {
                if (disposing)
                { 
                    //release managed resources
                }
                //release unmanaged resources
                m_disposed = true;
            }
        }
    }
