        // Parameter used for StoredProcedure
        private class Parameter
        {
            public Parameter(string name, object value)
            {
                Name = name;
                Value = value;
            }
            public readonly string Name;
            public readonly object Value;
        }
        // Executes a given stored procedure with parameters and returns a SQLDataReader
        private static SqlDataReader ExecuteDataReader(string name, SqlConnection dbConnection, List<Parameter> parameters = null)
        {
            if (parameters == null)
                parameters = new List<Parameter>();
            using (var command = new SqlCommand(name, dbConnection) { CommandType = CommandType.StoredProcedure })
            {
                foreach (var parameter in parameters)
                    command.Parameters.AddWithValue(parameter.Name, parameter.Value);
                return command.ExecuteReader();
            }
        }
        // Executes a given stored procedure with parameters
        private static void ExecuteNonQuery(string name, SqlConnection dbConnection, List<Parameter> parameters = null)
        {
            if (parameters == null)
                parameters = new List<Parameter>();
            using (var command = new SqlCommand(name, dbConnection) { CommandType = CommandType.StoredProcedure })
            {
                foreach (var parameter in parameters)
                    command.Parameters.AddWithValue(parameter.Name, parameter.Value);
                command.ExecuteNonQuery();
            }
        }
