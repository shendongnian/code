        /// <summary>
        /// A wrapper for queries executed by EF.
        /// </summary>
        internal class EntityFrameworkQueryProvider : QueryProvider
        {    
            protected override object Execute(Expression expression)
            {
                try
                {
                    // this is required due to a bug in how EF multi-threads when Transactions are used.
                    if (Transaction.Current != null) Monitor.Enter(EntityFrameworkExtensions.SyncRoot);
    
                    // enumerate is a simple extension method that forces enumeration of the IQueryable, thus making it actually get executed during the lock
                    return Expression.Lambda(expression).Compile().DynamicInvoke().Enumerate();
                }
                finally
                {
                    if (Transaction.Current != null) Monitor.Exit(EntityFrameworkRepositoryProvider.SyncRoot);
                }
            }
        }
