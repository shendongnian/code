C#
public async Task<bool> CheckAccountAsync(string rowrequest_)
{
  Extract extract = new Extract();
  string password = string.Empty, username = string.Empty, returndata = string.Empty;
  DatabaseConnection connection = new DatabaseConnection();
  username = extract.ExtractValue(rowrequest_, "username");
  password = extract.ExtractValue(rowrequest_, "password");
  string connectionStr = "frozenfiredb::std@basicconnection~(((dbuser)program(*dbuser)(dbpassword)K%ls!Sfgh3lloW%0rld45(*dbpassword)(dbtable)CasinoUser(*dbtable))(read_content)" + username + "(*read_content))";
  returndata = await connection.StaticConnectionAsync(connectionStr);
  return !returndata.StartsWith("FILE ERROR") && password == returndata;
}
If this isn't possible (due to API limitations) or feasible (too much work for now), **and** if your code is in a GUI app (not ASP.NET), then you can keep this method synchronous and just *call* it asynchronously using `Task.Run`:
C#
public bool CheckAccount(string rowrequest_)
{
  Extract extract = new Extract();
  string password = string.Empty, username = string.Empty, returndata = string.Empty;
  DatabaseConnection connection = new DatabaseConnection();
  username = extract.ExtractValue(rowrequest_, "username");
  password = extract.ExtractValue(rowrequest_, "password");
  string connectionStr = "frozenfiredb::std@basicconnection~(((dbuser)program(*dbuser)(dbpassword)K%ls!Sfgh3lloW%0rld45(*dbpassword)(dbtable)CasinoUser(*dbtable))(read_content)" + username + "(*read_content))";
  returndata = connection.StaticConnection(connectionStr);
  return !returndata.StartsWith("FILE ERROR") && password == returndata;
}
...
string rowrequest = ...;
bool result = await Task.Run(() => CheckAccount(rowrequest));
  [1]: https://blog.stephencleary.com/2014/05/a-tour-of-task-part-1-constructors.html
