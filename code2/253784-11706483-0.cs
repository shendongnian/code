    public static class FluentMigratorExtensions
    {
        public static void CreateNonClusteredPrimaryKey(this Migration migration, string indexName, string columnName, string tableName, string schemaName = "dbo")
        {
            var sql =
                @"ALTER TABLE [{3}].[{2}] ADD CONSTRAINT {0} PRIMARY KEY NONCLUSTERED ({1});";
            sql = string.Format(sql, indexName, columnName, tableName, schemaName);
            migration.Execute.Sql(sql);
        }
    }
