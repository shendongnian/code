    using (OleDbConnection conn = new OleDbConnection(connectionString))
        {
            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"update [Sh1$] set j = j + ' AAAA ' where a = '" + excelData.Rows[i]["a"].ToString() + "'";
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //exception here
            }
            finally
            {
                 conn.Close();
                 conn.Dispose();
            }
        }
