    long test = 8131818060;
    string sql = @"select Sites_IP_Rede from tblRamais where E164 = '" + test.ToString() + "'";
    SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder
    {
        InitialCatalog = "xxx",
        DataSource = @"127.0.0.1\V2016",
        UserID = "xxx",
        Password = "xxx"
    };
    SqlConnection con = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
    con.Open();
    SqlCommand command = new SqlCommand(sql, con);
    var ip = command.ExecuteScalar();
    con.Close();
    MessageBox.Show("IP Value: " + ip.ToString());
