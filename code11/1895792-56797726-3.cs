         long sum=0;
         private void enter(object sender, KeyEventArgs e)
                {
                    try
                    {
                        if (e.Key == Key.Enter)
                        {
                            SqlConnection com = new SqlConnection("Server = localhost; database = PrimaSOFT ; integrated security = true");
        
                            SqlCommand cmd = new SqlCommand("produktit", com);
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Barkodi", txtBarkodi.Text);
                            //Created a new DataTable
        
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
        
                            com.Open();//Open the SQL connection
        
                            SqlDataReader reader = cmd.ExecuteReader();//Create a SqlDataReader
        
                            while (reader.Read())//For each row that the SQL query returns do
                            {
                                DataRow dr = dataTable.NewRow();//Create new DataRow to populate the DataTable (which is currently binded to the DataGrid)
                                dr[0] = reader[0];//Fill DataTable column 0 current row (Product) with reader[0] (Product from sql)
                                dr[1] = reader[1];
                                dr[2] = reader[2];
                                dr[3] = reader[3];
                                dr[4] = reader[4];
                                // sum+= Convert.ToInt64(reader[4]); // use the total index instead of 4 . or use reader["total"];
        
                                dataTable.Rows.Add(dr);//Add the new created DataRow to the DataTable
        // or maybe dtgartikujt.Rows.Add(dr);
                            }
    
    // textbox1.Text=sum.Tostring();
                        }
                    }
