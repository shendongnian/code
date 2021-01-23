    for (int i = 0; i < dt.Rows.Count; i++)
    {
        for (int j = 0; j < dataTable.Columns.Count; j++)
        {
            if (Convert.ToInt32(dt.Rows[i][j]) == 0)
            {
                dt.Rows[i][j] = "";
            }
        }
    }
