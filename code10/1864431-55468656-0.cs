    public static ArrayList DbQueryToArry()
        {
            string SqlCString = "connString";
            SqlConnection connection = null;
            ArrayList valuesList = new ArrayList();
            connection = new SqlConnection(SqlCString);
            using (connection)
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Select CLIENTNO, ACCOUNT_Purpose from audit.ACCOUNTS_AUDIT", connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        valuesList.Add(Convert.ToString(reader[0]));
                        valuesList.Add(Convert.ToString(reader[1])); // add to valuelist
                    }
                }
                reader.Close(); // close reader
                
            } //dispose connection
            return valuesList;
        }
    
