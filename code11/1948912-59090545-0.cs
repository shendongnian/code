     if (GPBox.IsChecked == true)
        {
            connect = new MySqlConnection(connectionString);
            cmd = new MySqlCommand("select distinct * from gpSurgery", connect);
            connect.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            connect.Close();
            DataGrid1.DataContext = dt;
        }  
