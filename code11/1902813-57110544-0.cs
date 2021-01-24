    string conn = "datasource=localhost;port=3306;username=root;password=;CharSet=utf8mb4;";
                    string query = "SELECT * FROM project1.workers";
    
    
                    connection = new MySqlConnection(conn);
                    adapter = new MySqlDataAdapter(query, connection);
    
    
                    ds = new DataSet();
                    adapter.Fill(ds, "workers");
                    datagrdvPracownicy.DataSource = ds.Tables["workers"];
    connection.Close();
