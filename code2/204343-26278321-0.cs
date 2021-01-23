        private int GetColumnIndexByName(GridView grid, string name)
        {
            for (int i = 0; i < grid.HeaderRow.Cells.Count; i++)
            {
                if (grid.HeaderRow.Cells[i].Text.ToLower().Trim() == name.ToLower().Trim())
                {
                    return i;
                }
            }
            return -1;
        }
