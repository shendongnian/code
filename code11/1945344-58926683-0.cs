            DataTable dt = new DataTable();
            SqlDataAdapter da;
            string sql = "SELECT * FROM Project WHERE ProjectName LIKE @Search OR NumberOfUnits LIKE @Search OR Location LIKE @Search";
            using (var con = new SqlConnection(@"Data Source=HAZWAN-PC\SQLEXPRESS;Initial Catalog=wantest2;Integrated Security=True"))
            {
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Search", "%" + txtSearch.Text + "%");
                   
                    try
                    {
                        con.Open();
                        //cmd.ExecuteNonQuery(); 
                        //Instead of above method you have to use 
                        da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        da.Dispose();
                        dataGridView1.DataSource = dt;
                        con.Close();
                    }
                    catch (SqlException er)
                    {
                        con.Close();
                        dataGridView1.DataSource = null;
                        MessageBox.Show("There was an error accessing your data. DETAIL: " + er.ToString());
                    }             
                     
                }
            }
you can wrap above code in One Method like `RefreshGrid` or `BindGrid` etc. and call that method based on the requirement. 
