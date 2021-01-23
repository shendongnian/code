	using (TransactionScope txn = new TransactionScope())
	{
		using (DbCommand cmd = Banco.GetSqlStringCommand(sql))
		{
			string line = null;
			while ((line = reader.ReadLine()) != null)
			{
				// Set the parameters for the command at this point based on the current line
				Banco.ExecuteNonQuery(cmd);
				txn.Complete();
			}
		}
	}
