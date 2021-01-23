    using (System.Data.IDbCommand command = connection.CreateCommand())
    {
    	command.CommandText = string.Format("SELECT COUNT(1) FROM {0}", tableName);
    	object count = command.ExecuteScalar();
    	System.Diagnostics.Trace.WriteLine(count.GetType());
    	int iCount = (int)count; //statement 1
    }
