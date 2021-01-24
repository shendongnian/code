    public static string GetConnectionString(string name)
    {
    	return XDocument.Parse(System.IO.File.ReadAllText(ConfigurationManager.AppSettings["ConnectionStringsPath"]))
    		.Descendants("connectionStrings")
    		.Elements()
    		.Where(x => x.Attribute("name").Value.ToLower().Equals(name.ToLower()))
    		.Select(x => x.Attribute("connectionString").Value)
    		.First();
    }
