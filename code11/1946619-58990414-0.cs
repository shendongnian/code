csharp
private SqlConnection ManageSQLConnection(bool disconnect = false)
{
	static SqlConnection conn = null;
	if (conn==null)
	{
		// Initialize your connection
	}
	if(disconnect)
	{
		// Dispose connection
	}
	return conn;
}
private void SearchOrderID()
{
	var conn = ManageSQLConnection();
	// Insert logic here
}
Don't forget to dispose the connection when disposing your class.
