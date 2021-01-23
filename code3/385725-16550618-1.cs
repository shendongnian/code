    private void chData_MouseMove(object sender, MouseEventArgs e)
    {
        Point mousePoint = new Point(e.X, e.Y);
    
        Chart.ChartAreas[0].CursorX.SetCursorPixelPosition(mousePoint, true);
        Chart.ChartAreas[0].CursorY.SetCursorPixelPosition(mousePoint, true);
    
        // ...
    }
