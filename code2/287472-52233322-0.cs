    public class TransactionInterceptor : IInterceptor
    {
        private readonly IUnitOfWork _UnitOfWork;
        public TransactionInterceptor(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }
    
        public void Intercept(IInvocation invocation)
        {
            _UnitOfWork.Begin();
    
            try
            {
                invocation.Proceed();
                _UnitOfWork.Commit();
            }
            catch (Exception)
            {
                _UnitOfWork.RollBack();
                throw;
            }
        }
    }
