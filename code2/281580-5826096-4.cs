    Type contextType = typeof(test_Entities);
    string innerConnectionString = ConfigurationManager.ConnectionStrings["Inner"].ConnectionString;
    string entConnection = 
        string.Format(
            "metadata=res://*/{0}.csdl|res://*/{0}.ssdl|res://*/{0}.msl;provider=System.Data.SqlClient;provider connection string=\"{1}\"",
            contextType.Name,
            innerConnectionString);
    object objContext = Activator.CreateInstance(contextType, entConnection);
    return objContext as test_Entities; 
