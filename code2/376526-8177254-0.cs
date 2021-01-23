	private static string GetConnectionString(string name)
	{
		return WebConfigurationManager.ConnectionStrings[name].ConnectionString;
	}
    using (var cn = new SqlConnection(GetConnectionString("MyDbConn"))) { ... }
