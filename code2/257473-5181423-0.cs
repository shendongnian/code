    public static GridItemCollection GetAllGridEntries(PropertyGrid grid)
    {
        if (grid == null)
            throw new ArgumentNullException("grid");
        object view = grid.GetType().GetField("gridView", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(grid);
        return (GridItemCollection)view.GetType().InvokeMember("GetAllGridEntries", BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance, null, view, null);
    }
