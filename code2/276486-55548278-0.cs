            if (dt1.Columns.Contains("ID"))
            {
                for (int i = dt1.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr = dt1.Rows[i];
                    if (dr["ID"].ToString() != "" && dr["ID"].ToString() != null)
                    {
                        dr.Delete();
                    }
                }
                dt1.Columns.Remove("ID");
            }
