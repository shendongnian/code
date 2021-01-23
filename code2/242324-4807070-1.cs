    void AssociatedObject_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (sender is ScrollableDataGrid)
        {
            ScrollableDataGrid grid = (sender as ScrollableDataGrid);
                
            if (grid.SelectedItem != null)
            {
                grid.Dispatcher.BeginInvoke(delegate
                {
                    grid.ScrollToBottom();
                    grid.UpdateLayout();
                    grid.ScrollIntoView(grid.SelectedItem, null);
                });
            }
        }
    }
