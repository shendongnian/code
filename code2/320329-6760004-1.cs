    SqlCommand cmd = new SqlCommand("Your query", con);
                SqlDataReader rdr;
                rdr = cmd.ExecuteReader();
    
                DataTable dt = new DataTable();
    
                DataRow newRow = dt.NewRow();
    
    
                DataColumn dc = new DataColumn();
    
                
                rdr.Read();
                dt.Columns.Add(new DataColumn(rdr[Index].ToString()));
                rdr.Close();
               
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
    
                    dt.Columns.Add(new DataColumn(rdr[Index].ToString()));
                }
              
                rdr.Close();
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string Amount = rdr[Index].ToString();
                    string EarnName = rdr[Index].ToString();
                    newRow[EarnName] = Amount;
                    
    
                }
                dt.Rows.Add(newRow);
    
                GridView1.DataSource = dt;
                GridView1.DataBind();
