    private void Grid_MouseMove(object sender, MouseEventArgs e)
    {
        Grid grid = sender as Grid;
        Point mousePoint = e.GetPosition(grid);
        double heightSum = grid.RowDefinitions[0].ActualHeight;
        int activeRow = 0;
        for (; heightSum < mousePoint.Y; activeRow++)
        {
            heightSum += grid.RowDefinitions[activeRow].ActualHeight;
        }
        GridExtensions.SetMouseOverRowDefinition(grid, activeRow);
    }
    // No RowDefinition is beeing hoovered, set MouseOverRowDefinition to -1
    private void Grid_MouseLeave(object sender, MouseEventArgs e)
    {
        Grid grid = sender as Grid;
        GridExtensions.SetMouseOverRowDefinition(grid, -1);
    }
