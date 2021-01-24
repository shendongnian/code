    for (int j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
            {
                data = ds.Tables[0].Columns[j].ColumnName;
                xlWorkSheet.Cells[1, j + 1] = data;
            }
    for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
        {
            for (j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
            {
                data = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                xlWorkSheet.Cells[i + 2, j + 1] = data;
            }
        }
