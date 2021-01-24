    for (int col = outputTable.Columns.Count - 1; col >= 0; col--)
    {
        bool toDelete = true;
        for (int row = 0; row < outputTable.Rows.Count; row++)
        {
            if (outputTable.Rows[row][col] != null)
            {
                toDelete = false;
            }
        }
        if (toDelete)
        {
            outputTable.Columns.RemoveAt(col);
        }
     }
