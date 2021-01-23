    using (var scope = new TransactionScope())
    using (var c = new FbConnection(m_connection))
    {
    		using (var cmd = new FbCommand("DELETE_MESSAGES_QUEUE", c))
    		{
    			cmd.CommandType = System.Data.CommandType.StoredProcedure;
    			cmd.Parameters.Add("INQUEUENAME", queueName);
    
    			cmd.ExecuteNonQuery();
    		}
    		using (var cmd = new FbCommand("DELETE_QUEUE", c))
    		{
    			cmd.CommandType = System.Data.CommandType.StoredProcedure;
    			cmd.Parameters.Add("INQUEUENAME", queueName);
    
    			cmd.ExecuteNonQuery();
    		}
    		scope.Complete();
    }
