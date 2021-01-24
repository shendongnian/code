    private void OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        var fe = e.OriginalSource as FrameworkElement;
        if (fe != null)
        {
            var blueprint = fe.DataContext as BluePrint;
            if (blueprint != null)
            {
                //open window...
            }
        }
    }
