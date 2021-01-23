            SqlConnection sql_connect = new SqlConnection();
            SqlCommand sql_command = new SqlCommand();
            string connetionString = @"server=ALI-LAP\SQLEXPRESSR2;Trusted_Connection=yes;database=XXX;";
    
             SqlDataAdapter sql_ada = new SqlDataAdapter();
             DataTable dt = new DataTable();
    
                    sql_connect.ConnectionString = connetionString;
                    sql_command.Connection = sql_connect;
                    sql_command.CommandText = "SELECT * FROM XXX";
    
                    sql_ada.SelectCommand = sql_command;
                    sql_ada.Fill(dt);
    
                    dataGridView.DataSource = dt;
