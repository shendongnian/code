    DbProviderFactory m_factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
		DbConnection m_connection = m_factory.CreateConnection();
		m_connection.ConnectionString = _connstrbldr.ConnectionString;
		m_connection.Open();
		using (DbCommand cmd = m_connection.CreateCommand())
		{
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = "";
			cmd.ExecuteNonQuery();
		}
