    public static bool IsInEditMode(PropertyGrid grid)
    {
        if (grid == null)
            throw new ArgumentNullException("grid");
        Control gridView = (Control)grid.GetType().GetField("gridView", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(grid);
        Control edit = (Control)gridView.GetType().GetField("edit", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(gridView);
        Control dropDownHolder = (Control)gridView.GetType().GetField("dropDownHolder", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(gridView);
        return ((edit != null) && (edit.Visible & edit.Focused)) || ((dropDownHolder != null) && (dropDownHolder.Visible));
    }
