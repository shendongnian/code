    public SomeDbDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["SomeDbConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
