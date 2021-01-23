	// create an instance of the Data Model	
	NITESMOVE_EDM EDMinst = new NITESMOVE_EDM();
	// create a connection string builder
	System.Data.EntityClient.EntityConnectionStringBuilder entityBuilder = new System.Data.EntityClient.EntityConnectionStringBuilder();
	// Set the Metadata location, by querying an Entity in the model
	entityBuilder.Metadata = string.Format(@"res://*/{0}.csdl|res://*/{0}.ssdl|res://*/{0}.msl", EDMinst.NM_PATHS.EntitySet.ElementType.NamespaceName);
