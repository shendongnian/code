    public static ConnectionString GetConnectionString(string name)
    {
    	return XDocument.Parse(System.IO.File.ReadAllText(ConfigurationManager.AppSettings["ConnectionStringsPath"]))
    		.Descendants("connectionStrings")
    		.Elements()
    		.Where(x => x.Attribute("name").Value.ToLower().Equals(name.ToLower()))
    		.Select(x => new ConnectionString()
    		{
    			Name = x.Attribute("name").Value,
    			Provider = x.Attribute("providerName").Value,
    			Connection = x.Attribute("connectionString").Value
    		}
    		).First();
    }
