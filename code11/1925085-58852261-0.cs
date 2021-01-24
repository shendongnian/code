    public class TradeLoader : ITradeLoader
    {
        ...
    
        public async Task<SomeDataType> RunQuery()
        {
            ...
            var sqlCommand = CreateTradeQuery(someTargets, someGroups, someDateTime);
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                sql.Open();
                var command = new SqlCommand(sqlCommand.Sql, sql) {CommandTimeout = _timeout};
                foreach (var (name, value) in sqlCommand.NamedBindings)
                {
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = name;
                    parameter.Value = value;
                    command.Parameters.Add(parameter);
                }
                
                using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
                {
                    while (await dataReader.ReadAsync())
                    {
                        // read data here
                    }
                }
            }
            return data;
        }
    }
