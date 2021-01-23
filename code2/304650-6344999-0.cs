    Control parent = grid.Parent;
    int GridIndex = 0;
    if (parent != null)
    {
    	GridIndex = parent.Controls.IndexOf(grid);
    	parent.Controls.Remove(grid);
    }
    
    grid.RenderControl(hw);
    
    if (parent != null)
    {
    	parent.Controls.AddAt(GridIndex, grid);
    }
