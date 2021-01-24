public class AppDbContext : DbContext
    {
        
        public DbSet<Message> Messages { get; set; }
        IOptions<AppConfig> app_config;
        public AppDbContext(DbContextOptions<AppDbContext> options, IOptions<AppConfig> _app_config)
            : base(options)
        {
            app_config = _app_config;
            Database.EnsureCreated();
        }
        
        public IEnumerable<dynamic> DynamicListFromSql(string Sql, Dictionary<string, object> Params = null)
        {
            using (var cmd = Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandText = Sql;
                if (cmd.Connection.State != ConnectionState.Open) { cmd.Connection.Open(); }
                if (Params != null)
                    foreach (KeyValuePair<string, object> p in Params)
                    {
                        DbParameter dbParameter = cmd.CreateParameter();
                        dbParameter.ParameterName = p.Key;
                        dbParameter.Value = p.Value;
                        cmd.Parameters.Add(dbParameter);
                    }
                using (var dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        var row = new ExpandoObject() as IDictionary<string, object>;
                        for (var fieldCount = 0; fieldCount < dataReader.FieldCount; fieldCount++)
                        {
                            row.Add(dataReader.GetName(fieldCount), dataReader[fieldCount]);
                        }
                        yield return row;
                    }
                }
            }
        }
    }
c#
string query =
                "SELECT" +
                "    message.SenderId AS sender_id," +
                "    COUNT(*) AS all_count_messages," +
                "    (SELECT COUNT(*) FROM Messages AS sub_message WHERE sub_message.SenderId = message.SenderId AND sub_message.IsReaded = 0) AS unreaded_messages," +
                "    (SELECT MIN(sub_message.DateCreate) FROM Messages AS sub_message WHERE sub_message.SenderId = message.SenderId) AS most_unreaded " +
                "FROM " +
                "    Messages AS message " +
                "GROUP BY " +
                "    message.SenderId " +
                "ORDER BY" +
                "    most_unreaded ";
                //"OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY", offset, fetch);
                foreach (var chat in db.DynamicListFromSql(query))
                {
                    
                }
  [1]: https://stackoverflow.com/questions/57519628/sql-data-projection-with-nested-query-in-ef-core/57521603#comment101508684_57519834
  [2]: https://stackoverflow.com/a/42419101/3963304
