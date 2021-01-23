            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            conn.ConnectionString = "Data Source=MICMIKE\\SQLEXPRESS;Initial Catalog=Enterprise;Integrated Security=True";
            conn.Open();
            string query = "Select Position from Position";// position column from position table
            cmd.Connection = conn;
            cmd.CommandText = query;
            
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string myItem = dr["Position"].ToString();
                checkedListBox1.Items.Add(myItem, true);//true means check the items. use false if you don't want to check the items or simply .....Items.Add(myItem);
            }
