c#
// Return early of tokens has nothing to insert
if (tokens.Length == 0)
	return ...;
query = "INSERT INTO tokenlist(token, user_id) VALUES";
for (int i = 0; i < tokens.Length; i++)
{
	query += $"(@token{i}, @loggedInId{i}),"
}
// Trim trailling comma as it leads to a SQL syntax error
query.TrimEnd(',');
// Technically not needed, could be removed
query += ";"
var command = new MySqlCommand(query);
for (int i = 0; i < tokens.Length; i++)
{
	command.Parameters.AddWithValue($"@token{i}", tokens[i]);
	command.Parameters.AddWithValue($"@loggedInId", loggedInId);
}
if (OpenConnection()) 
{
	command.Connection = mysqlcon;
	command.ExecuteNonQuery();
	CloseConnection();
}
