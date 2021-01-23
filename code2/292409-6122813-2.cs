    public class LoggingSqlClientDriver : SqlClientDriver
    {
        public override IDbCommand CreateCommand()
        {
            return new LoggingDbCommand(base.CreateCommand());
        }
    }
