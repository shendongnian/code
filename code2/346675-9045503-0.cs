    ribbon.PreviewMouseDoubleClick += ribbon_PreviewMouseDoubleClick;
    
    private void ribbon_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        e.Handled = true;
    }
