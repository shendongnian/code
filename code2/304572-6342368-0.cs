    private void menuItem_Click(object sender, RoutedEventArgs e)
    {
        var topLevelControl = GetTopLevelControl(this);
        if (topLevelControl != null && topLevelControl is Window1)
        {
            var currentWindow = topLevelControl as Window1;
            SecondControl ctrl = new SecondControl();   
            currentWindow.dp3.Children.Add(ctrl ); 
        }
    }
    DependencyObject GetTopLevelControl(DependencyObject control)  
    {
        DependencyObject tmp = control;
        DependencyObject parent = null;
        while((tmp = VisualTreeHelper.GetParent(tmp)) != null)
        {
            parent = tmp;
        }
        return parent;
    }
