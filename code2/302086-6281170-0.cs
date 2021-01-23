    string somevalue = String.Empty;
    if (ds.Tables.Count > 0)
            {
                System.Data.DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    System.Data.DataRow dr = dt.Rows[0];
                    if (dt.Columns.Count>0 && dt.Columns.Contains("col1"))
                    {
                       somevalue = dr["col1"].ToString();
                    }
                }
            }
