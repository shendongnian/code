    private void TreeViewItem_Drop(object sender, DragEventArgs e)
    {
      if (e.Data.GetDataPresent("DragableTreeViewItem"))
      {
        var sourceItem = e.Data.GetData("DragableTreeViewItem") as TreeItem;
        var targetItemContainer = sender as TreeViewItem;
        var targetItem = targetItemContainer.DataContext as TreeItem;
      }
    }
