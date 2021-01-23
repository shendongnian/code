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
        GridExtensions.SetActiveRow(grid, activeRow);
    }
    private void Grid_MouseLeave(object sender, MouseEventArgs e)
    {
        Grid grid = sender as Grid;
        GridExtensions.SetActiveRow(grid, -1);
    }
