    for (int i = 0; i < grid.Columns.Count; i++)
    {
        grid.Columns[i].Width = new DataGridLength(1, DataGridLengthUnitType.Auto); 
        if (i == grid.Columns.Count - 1)
        {
        grid.Columns[i].Width = new DataGridLength(1, DataGridLengthUnitType.Star);
        }
    }
