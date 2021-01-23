                connMySql.Open();
                
                MySqlCommand cmd = new MySqlCommand(SQL, connMySql);
                DataSet ds = new DataSet();
                MySqlDataAdapter objDataAdapter = new MySqlDataAdapter(cmd);
                objDataAdapter.Fill(ds, "reading");
                connMySql.Close();
                // Each SQL statement result set 
                // will be in a DataTable in the DataSet
                gridView1.DataSource = ds.Tables[0];
                gridView1.DataBind();
                gridView2.DataSource = ds.Tables[1];
                gridView2.DataBind();
                
                
