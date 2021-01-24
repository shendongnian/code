	public DataTable exeReader(string cmd, OleDbParameter[] param)
	{
		using(OleDbConnection oConn = new OleDbConnection(connString))
		{
			DataTable AppData = new DataTable();
			oConn.Open();
			var oCmd = oConn.CreateCommand();
			oCmd.CommandText = cmd;
			try
			{
				using(var oReader = oCmd.ExecuteReader()) {
			        AppData.Load(oReader);
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}
		return AppData;
	}
