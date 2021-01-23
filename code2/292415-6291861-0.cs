    public class LoggingSqlClientDriver : SqlClientDriver
    {
        public override IDbCommand GenerateCommand(CommandType type, NHibernate.SqlCommand.SqlString sqlString, NHibernate.SqlTypes.SqlType[] parameterTypes)
        {
            SqlCommand command = (SqlCommand)base.GenerateCommand(type, sqlString, parameterTypes);
            LogCommand(command);
            return command;
        }}
