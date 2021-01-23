        public static void AddParameter(this SqlCommand sqlCommand, string parameterName, 
            SqlDbType sqlDbType, object item)
        {
            sqlCommand.Parameters.Add(parameterName, sqlDbType).Value = item ?? DBNull.Value;
        }
