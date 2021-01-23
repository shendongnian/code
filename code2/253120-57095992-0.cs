    	public HallLockerDataContext() : 
		base(ConfigurationManager.ConnectionStrings["MYDB1"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
