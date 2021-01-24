    public class UnitOfWork : IUnitOfWork
    {
        private readonly YouDatabaseContext _context = new YouDatabaseContext();
        private DbContextTransaction _dbContextTransaction;
        private GenericRepository<ExpenseReport> _expenseReportRepository;
        private GenericRepository<ExpenseItem> _expenseItemRepository;
        public GenericRepository<ExpenseReport> ExpenseReportRepository
        {
            get
            {
                if (_expenseReportRepository == null)
                {
                    _expenseReportRepository = new GenericRepository<ExpenseReport>(_context);
                }
                return _expenseReportRepository;
            }
            set
            {
                _expenseReportRepository = value;
            }
        }
		
		public GenericRepository<ExpenseItem> ExpenseItemRepository
        {
            get
            {
                if (_expenseItemRepository == null)
                {
                    _expenseItemRepository = new GenericRepository<ExpenseItem>(_context);
                }
                return _expenseItemRepository;
            }
            set
            {
                _expenseItemRepository = value;
            }
        }
        public void BeginTransaction()
        {
            _dbContextTransaction = _context.Database.BeginTransaction();
        }
        public void BeginTransaction(IsolationLevel isolationLevel)
        {
            _dbContextTransaction = _context.Database.BeginTransaction(isolationLevel);
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
        public void Commit()
        {
            if (_dbContextTransaction!=null)
            {
                _dbContextTransaction.Commit();
            }
        }
        public void RollBack()
        {
            if (_dbContextTransaction != null)
            {
                _dbContextTransaction.Rollback();
            }
        }
        private bool _disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                    _dbContextTransaction?.Dispose();
                }
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
