        int id, k;
        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0; Data Source=C:\\hi.mdb");
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from table2", con);
            con.Open();
            da.Fill(ds, "table2");
            
            for (int i = 0; i < ds.Tables["table2"].Rows.Count; i++)
            {
                DataRow row = ds.Tables["table2"].Rows[i];
                k++;
                for (int j = k; j < ds.Tables["table2"].Rows.Count; j++)
                {
                    DataRow row2 = ds.Tables["table2"].Rows[j];
                    if (row.ItemArray.GetValue(1).ToString() == row2.ItemArray.GetValue(1).ToString())
                    {
                        if (row.ItemArray.GetValue(3).ToString() == row2.ItemArray.GetValue(3).ToString())
                        {
                            id = int.Parse(row2.ItemArray.GetValue(0).ToString());
                            deletedupes(id);
                        }
                    }
                }
            }
            con.Close();
        }
        private void deletedupes(int num)
        {
            OleDbConnection con = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0; Data Source=C:\\hi.mdb");
            con.Open();
            
            OleDbCommand c = new OleDbCommand("Delete from table2 where id =?", con);
            c.Parameters.AddWithValue("id", num);
            c.ExecuteNonQuery();
            con.Close();
        }
