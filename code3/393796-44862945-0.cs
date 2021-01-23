    connStr = ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\temp\\Set.mdb;Persist Security Info=False");
            try
            {
                //Empty the table
                sql = "Delete from " + table;
                using (OleDbConnection conn = new OleDbConnection(connStr))
                {
                    conn.Open();
                    using (OleDbCommand cmd1 = new OleDbCommand(sql, conn))
                    {
                        cmd1.ExecuteNonQuery();
                    }
                }
            }
