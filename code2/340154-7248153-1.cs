    IList<int> myInts = new List<int>();
    
    using (IDbConnection connection = new SqlConnection("yourConnectionStringGoesHere"))
    {
        using (IDbCommand command = new SqlCommand("spName", connection))
        {
            command.CommandType = CommandType.StoredProcedure;
            //command.Parameters.Add(...) if you need to add any parameters to the SP.
            connection.Open();
    
            using (IDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
            {
                myInts.Add(Int32.Parse(reader["someIntField"].ToString()));
            }
        }
    }
