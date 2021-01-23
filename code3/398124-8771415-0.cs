    public void ReplaceItemAt(Grid grid, FrameworkElement fe, int row, int col)
    {
        // clear desired cell
        var items = grid.Children
            .Where(x => Grid.GetRow(x) == row && Grid.GetColumn(x) == col)
            .ToArray();
        foreach(var item in items) grid.Children.Remove(item);
        // make sure the new item is positioned correctly
        Grid.SetRow(fe, row);
        Grid.SetColumn(fe, col);
        // insert the new item into the grid
        grid.Children.Add(fe);
    }
