    // In MainWindow
    private bool IsOnExtendedFrame(int lParam)
    {
        int x = lParam << 16 >> 16, y = lParam >> 16;
        var point = PointFromScreen(new Point(x, y));
        // In XAML: <Grid x:Name="windowGrid">...</Grid>
        var result = VisualTreeHelper.HitTest(windowGrid, point);
        if (result != null)
        {
            // A control was hit - it may be the grid if it has a background
            // texture or gradient over the extended window frame
            return result.VisualHit == windowGrid;
        }
        // Nothing was hit - assume that this area is covered by frame extensions anyway
        return true;
    }
