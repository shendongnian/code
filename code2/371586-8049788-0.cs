    StringBuilder sb = new StringBuilder();
    
    foreach (DataTable table in ds.Tables)
    {
        for (int i = 0; i < table.Rows.Count; i++)
        {
            for (int j = 0; j < table.Columns.Count; j++)
            {
                sb.Append(table.Rows[i][table.Columns[j]]);
            }
        }
    }
