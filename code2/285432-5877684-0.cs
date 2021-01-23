	public IEnumerable GetAddress()
	{
		DataSet ds = DataOps.GetDataSet(string.Format(" select * from Students"));
		DataTable dt = ds.Tables[0];
		// The chances are that instead of string you will need a struct or a class
		List<string> retVal = new List<string>();
		foreach (DataRow row in dt)
		{
			// This will obviously depend on the table and return type
			retVal.Add(row["mycol"]);
		}
	}
