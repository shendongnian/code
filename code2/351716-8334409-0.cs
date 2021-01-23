    int j = 0;
    for (int i = 0; i < row.Cells.Count; i++)
    {
        if (fr_chart_grid.Columns[i].Visible == true)
        {
            drData[j] = row.Cells[i].Text;
            j++;
        }
    } 
