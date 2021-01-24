    public class DataBaseHelper
    {
        public static async Task<DataTable> GetDataAsync(string connectionString,
            string procedureName, List<Parameter> parameters)
        {
            try
            {
                var asyncConnectionString = new SqlConnectionStringBuilder(connectionString)
                {
                    AsynchronousProcessing = true
                }.ToString();
                using (var conn = new SqlConnection(asyncConnectionString))
                {
                    using (var SqlCommand = new SqlCommand())
                    {
                        SqlCommand.Connection = conn;
                        SqlCommand.CommandText = procedureName;
                        SqlCommand.CommandType = CommandType.StoredProcedure;
                        foreach (Parameter par in parameters)
                            if (par.Size != null)
                                SqlCommand.Parameters.Add(new SqlParameter(par.VariableName, par.Type, par.Size.Value) { Value = par.Value ?? DBNull.Value });
                            else
                                SqlCommand.Parameters.Add(new SqlParameter(par.VariableName, par.Type) { Value = par.Value ?? DBNull.Value });
                        conn.Open();
                        var data = new DataTable();
                        data.BeginLoadData();
                        using (var reader = await SqlCommand.ExecuteReaderAsync().ConfigureAwait(true))
                        {
                            if (reader.HasRows)
                                data.Load(reader);
                        }
                        data.EndLoadData();
                        return data;
                    }
                }
            }
            catch (Exception Ex)
            {
                // Log error or something else
                throw;
            }
        }
        public class Parameter
        {
            private string _variableName;
            public object Value { get; set; }
            public SqlDbType Type { get; set; }
            public int? Size { get; set; }
            public string VariableName
            {
                get
                {
                    if (_variableName.StartsWith("@") == false)
                        return "@" + _variableName;
                    return _variableName;
                }
                set
                {
                    _variableName = value;
                }
            }
            public Parameter(string variableName, SqlDbType type, object value)
            {
                _variableName = variableName;
                Type = type;
                Value = value;
                Size = null;
            }
            public Parameter(string variableName, SqlDbType type, object value, int size)
            {
                _variableName = variableName;
                Type = type;
                Value = value;
                Size = size;
            }
        }
        public class ProcedureParameters : List<Parameter>
        {
            public void Add(string variableName, SqlDbType type, object value)
            {
                this.Add(new Parameter(variableName, type, value));
            }
            public void Add(string variableName, SqlDbType type, int size, object value)
            {
                this.Add(new Parameter(variableName, type, value, size));
            }
        }
    }
