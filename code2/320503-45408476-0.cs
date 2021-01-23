    DataTable tbl = new DataTable();
    using (var con = new MySqlConnection { ConnectionString = conn.config })
    {
          using (var command = new MySqlCommand { Connection = con })
          {
               if (con.State == ConnectionState.Open)
                    con.Close();
               con.Open();
               command.CommandText = @"SELECT * FROM company where company_name Like Concat(@search,'%')";
               command.Parameters.AddWithValue("@search", textBoxSearchCompany.Text);
               tbl.Load(command.ExecuteReader());
               foreach(DataRow row in tbl.Rows)
               {
                   ListViewItem lv = new ListViewItem(row[1].ToString());
                   lv.SubItems.Add(row[2].ToString());
                   lv.SubItems.Add(row[28].ToString());
                   lv.SubItems.Add(row[29].ToString());
                   listView1.Items.Add(lv);
               }
          }
    }
