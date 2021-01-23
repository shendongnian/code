        void IDisposable.Dispose
        {   
            get
            {
                lock (this)
                {
                    if (m_Disposed == false)
                    {
                        Cleanup();
                        m_Disposed = true;
                        GC.SuppressFinalize(this);
                    }
                }
            }
        }
