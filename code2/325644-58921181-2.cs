    for (int i = 0; i < grid.Columns.Count; i++)
    {
        if (i == grid.Columns.Count - 1)
        {
            grid.Columns[i].Width = new DataGridLength(1, DataGridLengthUnitType.Star);
        }
        else
        {
            grid.Columns[i].Width = new DataGridLength(1, DataGridLengthUnitType.Auto); 
        }
    }
