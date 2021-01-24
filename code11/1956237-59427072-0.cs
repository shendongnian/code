    [DebuggerStepThrough]
    public class DatabaseTransactionInterceptor : IInterceptor
    {
        private readonly IDBEngine _dbEngine;
        public DatabaseTransactionInterceptor(IDBEngine dbEngine) => _dbEngine = dbEngine;
        public void Intercept(IInvocation invocation)
        {
            try
            {
                Proceed(invocation);
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
        private static void Proceed(IInvocation invocation)
        {
            invocation.Proceed();
        }
        [DebuggerStepperBoundary]
        private static bool ShouldTerminate(IInvocation invocation) =>
            !invocation.ContainsAttribute<DoNotTerminateAttribute>();
    }
