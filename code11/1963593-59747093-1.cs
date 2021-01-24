    private void TreeViewItem_Drop(object sender, DragEventArgs e)
    {
      if (e.Data.GetDataPresent("DragableTreeViewItem"))
      {
        var sourceItem = e.Data.GetData("DragableTreeViewItem") as TreeItem;
        var dropTargetItemContainer = sender as TreeViewItem;
        var dropTargetItem = targetItemContainer.DataContext as TreeItem;
      }
    }
