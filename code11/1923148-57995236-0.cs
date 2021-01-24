MySqlDataReader login = cmd.ExecuteReader();
if (login.Read())
{
    conn.Close();
    return true;
}
else
{
    conn.Close();
    return false;
}
The only thing we are doing here is finding out if `login` contains any rows. But we are not doing anything *with* those rows.
Let's try something like this instead:
MySqlDataReader login = cmd.ExecuteReader();
while (login.Read())
{
    var something1 = login.GetString(0); // this will get the value of the first coluomn
    var something2 = login.GetString(1); // this will get the value of the second coluomn
}
Or, if you are adding the results to an object:
MySqlDataReader login = cmd.ExecuteReader();
List<MyObject> myObjectList  = new List<MyObject>;
while (login.Read())
{
    MyObject myObject  = new MyObject;
    myObject.something1 = login.GetString(0); // this will get the value of the first coluomn
    myObject.something2 = login.GetString(1); // this will get the value of the first coluomn
    myObjectList.Add(myObject);
}
if (myObjectList.Count > 0)
{
    return true;
}
else
{
    return false;
}
You will need to adjust to meet your needs, but hopefully, this will get you there.
More info here: [SqlDataReader.Read Method][1]
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqldatareader.read?view=netframework-4.8
