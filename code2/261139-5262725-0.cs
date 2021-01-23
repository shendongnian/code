    for (int i = 0; i < dt.Columns.Count; i++)
    {
        string expression = "SUM(" + dt.Columns[i].ColumnName + ")";
        GridView1.FooterRow.Cells[i].Text = dt.Compute(expression, "").ToString();
    }
