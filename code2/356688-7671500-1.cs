    public class DisposableClass : IDisposable
    {
        ~DisposableClass()
        {
            Dispose(false);
        }
        private bool disposed = false;
        protected bool Disposed
        {
            get
            {
                return (disposed);
            }
        }
        public override void Transform(Engine engine, Package package)
        {
            if( Disposed )
            {
                 throw new ObjectDisposedException();
            }
            Initialize(engine, package);
            m_Logger.Info("Start of Page Metadata Values");
            tc.Publication pubObject= m_Engine.GetSession().GetObject(m_Publication.Id) as tc.Publication;          
            if (pubObject != null)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(ut.RenderPageLocale(pubObject));
            }
            package.PushItem("PageMetaDataValues", package.CreateStringItem(ContentType.Xml, RenderCurrentPageXML()));
            m_Logger.Info("End of Page Metadata Values");
        }
    
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                disposed = true;
                // Clean up all managed resources
            }
                
            // Clean up all native resources
        }
    }
