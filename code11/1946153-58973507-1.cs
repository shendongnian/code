    public interface IUnitOfWork<TDbContext> : IDisposable where TDbContext : DbContext
    {
        TDbContext Context { get; } 
    
        int SaveChanges();
    }
    
    public class UnitOfWork : IUnitOfWork<YourDbContext>
    {
        private YourDbContext _context = null;
        TDbContext IUnitOfWork<YourDbContext>.Context
        {
            get { return _context ?? (_context = new YourDbContext("YourConnectionString"); }
        }
    
        int IUnitOfWork<YourDbContext>.SaveChanges()
        {
            if(_context == null)
                return 0;
           return _context.SaveChanges();
        }
    
        public void Dispose()
        { 
            try
            {
               if (_context != null)
                  _context.Dispose();
            }
            catch (ObjectDisposedException)
            { }
        }
    }
