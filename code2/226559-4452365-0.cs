    <TreeView TreeViewItem.Expanded="OnExpanded" ... >
    private void OnExpanded(object sender, RoutedEventArgs e)
    {
          TreeViewItem tvi = e.OriginalSource as TreeViewItem;
          if (tvi != null)
          {
            tvi.ItemsSource = GetDatabases();
          }
    }
