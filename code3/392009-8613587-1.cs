	var uriString = ConfigurationManager.AppSettings["SQLSERVER_URI"];
	var uri = new Uri(uriString);
	var connectionString = new SqlConnectionStringBuilder
	{
		DataSource = uri.Host,
		InitialCatalog = uri.AbsolutePath.Trim('/'),
		UserID = uri.UserInfo.Split(':').First(),
		Password = uri.UserInfo.Split(':').Last(),
		MultipleActiveResultSets = true,
	}.ConnectionString;
