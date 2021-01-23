    public class SpringThreadStorageModule : IHttpModule
    {
        static SpringThreadStorageModule()
        {
            LogicalThreadContext.SetStorage(new HybridContextStorage());
        }
     
        #region IHttpModule Members
        public void Dispose()
        {
            // do nothing
        }
        public void Init(HttpApplication context)
        {
            // we just need the staic init block.
        }
        #endregion
    }
