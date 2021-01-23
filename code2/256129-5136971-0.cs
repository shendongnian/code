    <DataGrid VirtualizingStackPanel.IsVirtualizing="True"
              VirtualizingStackPanel.VirtualizationMode="Recycling"
              DataContextChanged="dataGrid_DataContextChanged"
              ...>
    private void dataGrid_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        ScrollViewer scrollViewer = GetVisualChild<ScrollViewer>(dataGrid);
        if (scrollViewer != null)
        {
            scrollViewer.ScrollToTop();
        }
    }
