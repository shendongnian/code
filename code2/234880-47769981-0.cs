    public class UtcInterceptor : DbCommandInterceptor
    {
        public override void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            base.ReaderExecuted(command, interceptionContext);
            
            if (interceptionContext?.Result != null && !(interceptionContext.Result is UtcDbDataReader))
            {
                interceptionContext.Result = new UtcDbDataReader(interceptionContext.Result);
            }
        }
    }
