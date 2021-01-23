    public static class NLogExtensions
    {
        // The commandText attribute must conatain at least the table name. 
        // Each identifier must be enclosed in square brackets: [schemaName].[tableName].
        public static void GenerateDatabaseTargetInsertQueries(this NLog.Config.LoggingConfiguration config)
        {
            var tableNameMatcher = new Regex(@"^(\[(?<schemaName>.+?)\].)?\[(?<tableName>.+?)\]$");
            var autoCommandTextDatabaseTargets =
                config.AllTargets
                    .OfType<DatabaseTarget>()
                    .Where(x => tableNameMatcher.IsMatch(x.CommandText()))
                    .Select(x => x);
            foreach (var databaseTarget in autoCommandTextDatabaseTargets)
            {
                databaseTarget.CommandText = databaseTarget.CreateCommandText();
            }
        }
        internal static string CommandText(this DatabaseTarget databaseTarget)
        {
            return ((NLog.Layouts.SimpleLayout)databaseTarget.CommandText).OriginalText;
        }
        internal static string CreateCommandText(this DatabaseTarget databaseTarget)
        {
            const string insertQueryTemplate = "INSERT INTO {0}({1}) VALUES({2})";
            return string.Format(
                    insertQueryTemplate,
                    databaseTarget.CommandText(),
                    string.Join(", ", databaseTarget.Parameters.Select(x => x.Name())),
                    string.Join(", ", databaseTarget.Parameters.Select(x =>
                    {
                        var sql = 
                            x.Nullable() 
                            ? string.Format("NULLIF({0}, '')", x.FullName()) 
                            : x.FullName();
                        
                        // Rename the SqlParameter because otherwise SqlCommand will complain about it.
                        x.Name = x.FullName();
                        return sql;
                    })));
        }
    }
