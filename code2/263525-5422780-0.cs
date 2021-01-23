      public static DataTable RemoveNulls(DataTable dt)
        {
            for (int a = 0; a < dt.Rows.Count; a++)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (dt.Rows[a][i] == DBNull.Value)
                    {
                        dt.Rows[a][i] = "";
                    }
                }
            }
            return dt;
        }
