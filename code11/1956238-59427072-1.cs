    [DebuggerStepThrough]
    public class DatabaseTransactionInterceptor : IInterceptor
    {
        private readonly IDBEngine _dbEngine;
        public DatabaseTransactionInterceptor(IDBEngine dbEngine) => _dbEngine = dbEngine;
        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
                if (ShouldTerminate(invocation))
                    _dbEngine.Terminate();
            }
            catch
            {
                if (ShouldTerminate(invocation))
                    _dbEngine.Terminate(true);
                throw;
            }
        }
        [DebuggerStepperBoundary]
        private static bool ShouldTerminate(IInvocation invocation) =>
            !invocation.ContainsAttribute<DoNotTerminateAttribute>();
    }
