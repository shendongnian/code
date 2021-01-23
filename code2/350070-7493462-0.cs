    public static class DataGridExtensions
    {
        public static void ScrollToLeft(this DataGrid dataGrid)
        {
            Border border = VisualTreeHelper.GetChild(dataGrid, 0) as Border;
            ScrollViewer scrollViewer = border.Child as ScrollViewer;
            scrollViewer.ScrollToLeftEnd();
        }
    }
