	public static class Extensions
	{    
	
		public static IEnumerable<dynamic> ExecuteSql(this UserQuery uq, string sql)
		{
			var connStr="Provider=SQLOLEDB.1;"+uq.Connection.ConnectionString; 
		
			OleDbConnection connection = new OleDbConnection(connStr);
			DataSet myDataSet = new DataSet();
			connection.Open();
		
			OleDbDataAdapter DBAdapter = new OleDbDataAdapter();
			DBAdapter.SelectCommand = new OleDbCommand(sql, connection); 
			DBAdapter.Fill(myDataSet);
			
			var result = myDataSet.Tables[0].AsDynamic();
			return result;
		}
	}
