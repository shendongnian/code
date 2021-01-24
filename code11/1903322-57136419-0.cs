    string conn = "datasource=localhost;port=3306;username=root;password=;CharSet=utf8mb4;";  
    string query = "SELECT * FROM RecipeTbl;"
        
    MySqlConnection connection = new MySqlConnection(conn);
    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
    
    DataSet ds = new DataSet();
    adapter.Fill(ds, "RecipeTbl");
    datagridview1.DataSource = ds.Tables["RecipeTbl"];
