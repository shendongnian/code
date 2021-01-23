        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                var path = "F:\\Projects\\dbf"; // Path of the folder containing dbf file.
                var fileName = "Invoices1.dbf";
                var constr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=DBASE III";
                var sql = "select * from " + fileName;
                var ds = new DataSet();
                using (var con = new OleDbConnection(constr))
                {
                    con.Open();
     
                    using (var cmd = new OleDbCommand(sql, con))
                    {
                        using (var da = new OleDbDataAdapter(cmd))
                        {
                            da.Fill(ds);
                            dataGridView1.DataSource = ds.Tables.Count > 0 
                                             ? ds.Tables[0].Copy() : new DataTable();
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }
