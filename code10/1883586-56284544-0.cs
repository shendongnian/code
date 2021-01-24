            DataSet ds = new DataSet();
            string query = "select * from tab_menu";
            SqlConnection sqlConnection = new SqlConnection(@"Persist Security Info=False;User ID=sa;Password=sa;Initial Catalog=EasyAdmin;Data Source=.");
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlConnection.Open();
            sqlDataAdapter.Fill(ds);
            sqlConnection.Close();
            dataGridView1.DataSource = ds.Tables[0];
