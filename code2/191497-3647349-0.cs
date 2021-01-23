    private void Hyperlink_Click(object sender, RoutedEventArgs e)
    {
        var hyperlink = sender as Hyperlink;
        if (hyperlink != null)
        {
            var rect = hyperlink.ContentStart.GetCharacterRect(
                LogicalDirection.Forward);
            var viewer = FindAncestor(hyperlink);
            if (viewer != null)
            {
                var screenLocation = viewer.PointToScreen(rect.Location);
                var wnd = new Window();
                wnd.WindowStartupLocation = WindowStartupLocation.Manual;
                wnd.Top = screenLocation.Y;
                wnd.Left = screenLocation.X;
                wnd.Show();
            }
        }
    }
    private static FrameworkElement FindAncestor(object element)
    {
        while(element is FrameworkContentElement)
        {
            element = ((FrameworkContentElement)element).Parent;
        }
        return element as FrameworkElement;
    }
