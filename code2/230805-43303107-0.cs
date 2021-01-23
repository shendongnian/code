        public SqlParameter GetNullableParameter(string parameterName, object value)
        {
            if (value == null)
            {
                return new SqlParameter(parameterName, value);
            }
            else
            {
                return new SqlParameter(parameterName, DBNull.Value);
            }
        }
