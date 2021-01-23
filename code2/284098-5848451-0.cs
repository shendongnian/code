        using (OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.JET.OLEDB.4.0;data source=c:\myDatabase.mdb"))
        {
            conn.Open();
                
            string tableToDelete = "myTable";   //table name
            bool tableExists = false;
            DataTable dt = conn.GetSchema("tables");
            foreach (DataRow row in dt.Rows)
            {
                if (row["TABLE_NAME"].ToString() == tableToDelete)
                {
                    tableExists = true;
                    break;
                }
            }
            if (tableExists)
            {
                using (OleDbCommand cmd = new OleDbCommand(string.Format("DROP TABLE {0}", tableToDelete), conn))
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Table deleted");
                }
            }
            else
                MessageBox.Show(string.Format("Table {0} not exists", tableToDelete));
        }
