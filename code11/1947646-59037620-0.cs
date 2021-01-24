    public class UnitOfWork : IUnitOfWork
    {
        private readonly PurchasingDataContext _context;
        public UnitOfWork(PurchasingDataContext context)
        {
            _context = context;
        }
        public void SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
