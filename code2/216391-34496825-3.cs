    for (int i = 0; i <= output.Tables[0].Rows.Count - 1; i++)
    {
        DataRow row = output.Tables[0].Rows[i];
        for (int j = 0; j <= output.Tables[0].Columns.Count - 1; j++)
        {
            if (object.ReferenceEquals(row[j], DBNull.Value))
            {
                row[j] = 0;
            }
            if (row[j].ToString().Length == 0)
            {
                row[j] = 0;
            }
        }
    }
