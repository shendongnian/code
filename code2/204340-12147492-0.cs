    private int GetColumnIndexByName(GridView grid, string name)
    {
            for(int i; i < grid.Columns.Count; i ++)
            {
                if (grid.Columns[i].HeaderText.ToLower().Trim() == name.ToLower().Trim())
                {
                    return i;
                }
            }
    
            return -1;
    }
