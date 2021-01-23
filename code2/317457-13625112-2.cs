    SqlConnection con = connection string;
            con.Open();
            string sql = "Create Table abcd (";
            foreach (DataColumn column in dt.Columns)
            {
                sql += "[" + column.ColumnName + "] " + "nvarchar(50)" + ",";
            }
            sql = sql.TrimEnd(new char[] { ',' }) + ")";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
    con.close();
