            public int ExecuteNonQuery(MySqlConnection connection, string commandText, params MySqlParameter[] commandParameters)
        {
            try
            {
                return AttemptActionReturnObject( () => MySqlHelper.ExecuteNonQuery(connection, commandText, commandParameters) );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString() + " For SQL Statement:" + commandText);
            }
        }
