csharp
MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder()
{
    Server = tbDbServername.Text.ToLower(),
    Port = (uint)System.Convert.ToInt32(tbDbServerPort.Text),
    UserID = tbDbServerUsername.Text.ToLower(),
    Password = tbDbServerPassword.Password,
    Database = tbDbServerDatabase.Text.ToLower(),
    SslMode = MySqlSslMode.Preferred
};
string connString = builder.ConnectionString;
