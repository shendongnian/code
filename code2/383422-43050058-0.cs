    private static void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
    {
            var scrollViewer = sender as ScrollViewer;
            if (e.ExtentHeightChange > 0)
            {
                scrollViewer.ScrollToEnd();
            }
            
    }
