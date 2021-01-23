    public static ISqlCommandTypeSelector UsingConnection(string connection)
    {
        return new SqlBuilder(connection);
    }
    private class SqlBuilder : ISqlCommandTypeSelector, ISqlParameterManager, ISqlExecutor
    {
        private string _connection;
        private string _sqltext;
        private CommandType _commandtype;
        private Action<Exception> _exceptionBehavior = DefaultExceptionBehavior;
        
        private IList<SqlParameter> _inParams;
        
        public SqlBuilder(string connection)
        {
            _connection = ConfigurationManager.ConnectionStrings[connection].ConnectionString;
            _inParams = new List<SqlParameter>();
        }
        public ISqlParameterManager GetTextCommandFor(string text)
        {
            _sqltext = text;
            _commandtype = CommandType.Text;
            return this;
        }
        public ISqlParameterManager GetProcCommandFor(string proc)
        {
            _sqltext = proc;
            _commandtype = CommandType.StoredProcedure;
            return this;
        }
        public ISqlExecutor OnException(Action<Exception> action)
        {
            _exceptionBehavior = action;
            return this;
        }
        public void ExecuteNonQuery()
        {
            try
            {
                using (var connection = new SqlConnection(_connection))
                using (var cmd = connection.CreateCommand())
                {
                    ConfigureCommand(cmd);
                    PopulateParameters(cmd);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                _exceptionBehavior(ex);
            }
        }
        public T ExecuteScalar<T>()
        {
            T result = default(T);
            try
            {
                using (var connection = new SqlConnection(_connection))
                using (var cmd = connection.CreateCommand())
                {
                    ConfigureCommand(cmd);
                    PopulateParameters(cmd);
                    connection.Open();
                    result = (T) cmd.ExecuteScalar();
                    return result;
                }
            }
            catch(InvalidCastException ex)
            {
                // rethrow?
            }
            catch(Exception ex)
            {
                _exceptionBehavior(ex);
            }
            return result;
        }
        public IDataReader ExecuteReader()
        {
            try
            {
                var connection = new SqlConnection(_connection);
                var cmd = connection.CreateCommand();
                ConfigureCommand(cmd);
                PopulateParameters(cmd);
                connection.Open();
                var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
            catch(Exception ex)
            {
                _exceptionBehavior(ex);
            }
            return null;
        }
        public ISqlExecutor AddParameters(object @params)
        {
            var type = @params.GetType();
            var props = type.GetProperties();
            foreach (var propertyInfo in props)
            {
                var param = new SqlParameter("@" + propertyInfo.Name, propertyInfo.GetValue(@params, null));
                param.Direction = ParameterDirection.Input;
                _inParams.Add(param);
            }
            return this;
        }
        public ISqlExecutor WithoutParams()
        {
            return this;
        }
        private void ConfigureCommand(SqlCommand cmd)
        {
            cmd.CommandText = _sqltext;
            cmd.CommandType = _commandtype;
        }
        private void PopulateParameters(SqlCommand cmd)
        {
            cmd.Parameters.AddRange(_inParams.ToArray());
        }
        private static void DefaultExceptionBehavior(Exception e)
        {
            // do something
        }
    }
