    public static class DatabaseExtensions
    {
        public static void AddInParameter(this Database database, DbCommand command, string name, SqlDbType dbType, object value)
        {
            ((SqlDatabase)database).AddInParameter(command, name, dbType, value);
        }
    }
