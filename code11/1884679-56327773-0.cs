        //sync version
        T GeneralExecuteAction<T>(Func<ISession, T> action)
        {
            lastDbError = DbError.Ok;
            using (var ctx = GetContextForStatement())
            {
                try
                {
                    T result = action(ctx.session);
                    ctx.CommitTransactionIfExists();
                    return result;
                }
                catch (Exception ex)
                {
                    ctx.RollbackTransactionIfExists();
                    lastDbError = new DbError(ex);
                    return default(T);
                }
            }
        }
        //async version 
        async Task<T> GeneralExecuteAction<T>(Func<ISession, Task<T>> action)
        {
            lastDbError = DbError.Ok;
            using (var ctx = GetContextForStatement())
            {
                try
                {
                    T result = await action(ctx.session);
                    await ctx.CommitTransactionIfExistsAsync();
                    return result;
                }
                catch (Exception ex)
                {
                    await ctx.RollbackTransactionIfExistsAsync();
                    lastDbError = new DbError(ex);
                    return default(T);
                }
            }
        }
