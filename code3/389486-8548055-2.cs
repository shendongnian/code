          con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= ..\\dbMert.mdb";
          con.Open();
        recordları
          DataSet ds = new DataSet();
          DataTable dt = new DataTable();
          ds.Tables.Add(dt);
          OleDbDataAdapter da = new OleDbDataAdapter();
          
          da = new  OleDbDataAdapter("Select * from Customer", con);
          da.Fill(dt);
          dataGridView1.DataSource = dt;
         
           
          foreach (DataRow row in dt.Rows)
          {
              foreach (DataColumn col in dt.Columns)
                  if(col.ToString() == "emailAdress")
                  comboBox1.Items.Add(row[col]);
          }
       
     
          con.Close();
        
