 c#
var builder = new SqlConnectionStringBuilder
{
    UserID = txtmyusername.Text,
    DataSource = txtmysource.Text,
    Password = txtmypassword.Text,
    InitialCatalog = txtmydatabasename.Text,
};
var connectString = builder.ConnectionString;
The crucial bit here is that it will apply the correct character escaping etc if (for example) any of the elements contain reserved / non-trivial characters such as whitespace, commas, quotes, etc.
