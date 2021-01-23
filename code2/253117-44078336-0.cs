    public dbDataContext() : 
				base(global::invdb.Properties.Settings.Default.Enventory_4_0ConnectionString, mappingSource)
		{
			OnCreated();
		}
