    internal class CustomMySqlMigrationSqlGenerator : MySqlMigrationSqlGenerator
    {
        protected override MigrationStatement Generate(CreateTableOperation op)
        {
            MigrationStatement statement = base.Generate(op);
            foreach (ColumnModel column in op.Columns)
            {
                if (column.MaxLength.HasValue)
                {
                    statement.Sql = statement.Sql.Replace("binary", $"binary({column.MaxLength.Value})");
                }
            }
            return statement;
        }
    }
