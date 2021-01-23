    void AssociatedObject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is DataGrid)
            {
                DataGrid grid = (sender as DataGrid);
                if (grid.SelectedItems.Count > 1) // <-------- Add row
                    return; //<-------- Add row
                if (grid.SelectedItem != null)
                {
                    grid.Dispatcher.BeginInvoke(new Action (delegate()
                    {                        
                        grid.UpdateLayout();
                        grid.ScrollIntoView(grid.SelectedItem, null);
                       
                    }));
                }
            }
        }
