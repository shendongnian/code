    public class AveragePeriodDaysService : IDisposable
    {
        private readonly MyDbContext _ctx;
        private readonly bool _ownContext;
    
        public AveragePeriodDaysService(MyDbContext ctx, bool ownContext)
        {
            _ctx = ctx;
            _ownContext = ownContext;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing) GC.SuppressFinalize(this);
            if (_ownContext) _ctx.Dispose();
        }
   
        public void Dispose()
        {
            Dispose(true);
        }
