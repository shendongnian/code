    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
    builder.DataSource = TextBox1.Text.Trim();
    builder.InitialCatalog = TextBox2.Text.Trim();
    builder.UserID = TextBox3.Text.Trim();
    builder.Password = TextBox4.Text.Trim();
    string result = builder.ConnectionString;
