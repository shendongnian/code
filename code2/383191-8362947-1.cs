    [System.Web.Services.WebMethod]
    public DataTable connectoToMySql()
    {
        string connString = "SERVER=localhost" + ";" +
            "DATABASE=testdatabase;" +
            "UID=root;" +
            "PASSWORD=password;";
        MySqlConnection cnMySQL = new MySqlConnection(connString);
        MySqlCommand cmdMySQL = cnMySQL.CreateCommand();
        MySqlDataReader reader;
        cmdMySQL.CommandText = "select * from testdata";
        cnMySQL.Open();
        reader = cmdMySQL.ExecuteReader();
        DataTable dt = new DataTable();
        dt.Load(reader);
        cnMySQL.Close();
        return dt;
    } 
