     using (
                OleDbConnection con =
                    new OleDbConnection(
                        @"Provider=Microsoft.ACE.OLEDB.12.0; Extended Properties=Excel 12.0;Data Source=" + SourceFile +
                        @";Extended Properties=Excel 12.0;"))
            {
                con.Open();
                string sql = String.Format("SELECT * FROM [{0}$]", sheetName);
                OleDbDataAdapter da = new OleDbDataAdapter(sql, con);
                da.Fill(dt);
            }
