    <TreeView TreeViewItem.Expanded="OnExpanded" ... >
    private void OnExpanded(object sender, RoutedEventArgs e)
    {
          TreeViewItem tvi = e.OriginalSource as TreeViewItem;
          if (tvi != null)
          {
            tvi.Focus(); // to ensure the expanded item is selected
            tvi.ItemsSource = ((Connection)myTreeView.SelectedItem).GetDatabases();
          }
    }
