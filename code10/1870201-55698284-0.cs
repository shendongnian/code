    public class Interceptor : IDbCommandInterceptor
    {
        void IDbCommandInterceptor.NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        { }
        void IDbCommandInterceptor.NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            if (interceptionContext.DbContexts.OfType<SomethingDbContext>().Any(x => !x.ShouldIntercept))
                return;
            var regex = "NOT NULL IDENTITY,";
            var replacement = "NOT NULL IDENTITY(100000,100000),";
            if (command.CommandText.StartsWith("CREATE TABLE [dbo].[Somethings]"))
                command.CommandText = Regex.Replace(command.CommandText, regex, replacement);
        }
        void IDbCommandInterceptor.ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        { }
        void IDbCommandInterceptor.ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        { }
        void IDbCommandInterceptor.ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        { }
        void IDbCommandInterceptor.ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        { }
    }
    public class SomethingConfiguration : DbConfiguration
    {
        public SomethingConfiguration()
        {
            AddInterceptor(new Interceptor());
        }
    }
