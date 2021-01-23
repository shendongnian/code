        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                var path  = @"F:\Projects\dbf\"; //Path of the folder containing dbf file
                var fileName = "Invoices1.dbf";
                string constr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=DBASE III";
                using (OleDbConnection con = new OleDbConnection(constr))
                {
                    var sql = "select * from " + fileName;
                    OleDbCommand cmd = new OleDbCommand(sql, con);
                    con.Open();
                    DataSet ds = new DataSet(); ;
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables.Count > 0)
                    {
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
