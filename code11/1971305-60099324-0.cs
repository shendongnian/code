// StringBuilder here, and the SqliteConnection below are 
// from the Microsoft.Data.Sqlite namespace v3.1.1
var connectionString = new SqliteConnectionStringBuilder()
{
  DataSource = connStr,
  Mode = SqliteOpenMode.ReadWriteCreate,
  Password = passStr
}.ToString();
connection = new SqliteConnection(connectionString);
connection.Open();
