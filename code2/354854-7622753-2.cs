    for (int i = 0; i < dataTable.Rows.Count; i++)
    {
        for (int j = 0; j < dataTable.Columns.Count; j++)
        {
            dataTable.Rows[i][j] = Crypto.Decrypt(dataTable.Rows[i][j].ToString());
        }
    }
