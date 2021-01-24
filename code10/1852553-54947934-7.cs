//using System.Data.SqlClient;
public DataTable SqlToDT (string connectionString, string procName)
{
	//receives connection string and stored procedure name
	//then returns the populated data table
	DataTable table = new DataTable();
	
	using (var connection = new SqlConnection(connectionString))
	using (var cmd = new SqlCommand(procName, connection))
	using (var adapter = new SqlDataAdapter(cmd))
	{
		cmd.CommandType = CommandType.StoredProcedure;
		da.Fill(table);
	} //the using statements will dispose the connection safely for you
	return table;
}
You can use this method like so:
