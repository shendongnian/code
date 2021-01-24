csharp
using (var connection = new MySqlConnection("...;IgnorePrepare=false"))
{
	// read float back
	float floatRead;
	using (var cmd = new MySqlCommand())
	{
		cmd.Connection = connection;
		cmd.CommandText = "select SomeFloat from TestFloatTable";
		
		// ADD THIS LINE
		cmd.Prepare();
		var reader = cmd.ExecuteReader();
		reader.Read();
		floatRead = (float)reader.GetValue(0); // GetValue returns a float object
	}
}
### Coerce to double precision
If you perform a calculation on the result, then MySQL will coerce it to double-precision. This will be formatted correctly on the wire and your client will read the correct result. Note that for MySqlConnector, the resulting value will now be typed as a `double`; quite possibly the ODBC connector works the same way:
csharp
// read float back
float floatRead;
using (var cmd = new System.Data.Odbc.OdbcCommand())
{
	cmd.Connection = connection;
	// ADD "+0" TO THE SELECT STATEMENT
	cmd.CommandText = "select SomeFloat+0 from TestFloatTable";
	var reader = cmd.ExecuteReader();
	reader.Read();
	floatRead = (float)(double)reader.GetValue(0); // GetValue returns a double object
	// ALTERNATIVELY, just use GetFloat
	floatRead = reader.GetFloat(0);
}
