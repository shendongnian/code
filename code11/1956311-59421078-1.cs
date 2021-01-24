    using (connect)
        {
            if (connect.State == ConnectionState.Open)
            connect.Close();
            connect.Open();
            adapter = new SqlDataAdapter("SELECT * FROM RetailInfo", connect);
            table = new DataTable();
            adapter.Fill(table);
            connect.Close();
        }
