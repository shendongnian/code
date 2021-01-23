    private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        var element = Mouse.DirectlyOver as DependencyObject;
        while (element != null && !(element is ColumnDataPoint))
        {
            element = VisualTreeHelper.GetParent(element);
        }
        if (element != null)
        {
            var columnDataPoint = element as ColumnDataPoint;
            Debug.WriteLine("X = " + columnDataPoint.IndependentValue);
            Debug.WriteLine("Y = " + columnDataPoint.DependentValue);
        }
    }
