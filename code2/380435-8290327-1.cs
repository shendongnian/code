	public void CreateEngine()
	{
		DataSet dsData = new DataSet();
		DataTable oTable = new DataTable("Piston");
		dsData.Tables.Add(oTable);
		Engine oEngine = new Engine();
		oEngine.AddParts(dsData);
	}
