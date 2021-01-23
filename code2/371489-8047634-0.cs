	string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
	string providerName = ConfigurationManager.ConnectionStrings["ConnectionString"].ProviderName;
	 
	DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);
	using (DbConnection cn = provider.CreateConnection())
	{
		cn.ConnectionString = connectionString
		
		using (DbCommand command = cn.CreateCommand())
		{
			command.CommandText = "GetAllCustomers";
			command.CommandType = CommandType.StoredProcedure;
			cn.Open();
			
			using (DbDataReader dr = command.ExecuteReader())
			{
				// Do Something...
			}
		}
	}
