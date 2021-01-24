    public static class MyExtensions
    {
      // Traverse TreeView
      public static bool TryGetContainerOfChildItem(this TreeView treeView, object item, out TreeViewItem itemContainer) => MyExtensions.TryGetItemContainer(treeView.Items, treeView.ItemContainerGenerator, item, out itemContainer);
      // Start traversal from specific TreeViewItem
      public static bool TryGetContainerOfChildItem(this TreeViewItem treeViewItem, object item, out TreeViewItem itemContainer)
      {
        itemContainer = treeViewItem.DataContext == item 
          ? treeViewItem
          : null;
        return itemContainer != null || MyExtensions.TryGetItemContainer(
          treeViewItem.Items,
          treeViewItem.ItemContainerGenerator,
          item,
          out itemContainer);
      }
      private static bool TryGetItemContainer(ItemCollection childItems, ItemContainerGenerator itemContainerGenerator, object item, out TreeViewItem itemContainer)
      {
        itemContainer = null;
        foreach (object childItem in childItems)
        {
          if (childItem == item)
          {
            itemContainer = itemContainerGenerator.ContainerFromItem(item) as TreeViewItem;
            return true;
          }
          var childItemContainer = itemContainerGenerator.ContainerFromItem(childItem) as TreeViewItem;
          if (MyExtensions.TryGetItemContainer(
            childItemContainer.Items,
            childItemContainer.ItemContainerGenerator,
            item,
            out itemContainer))
          {
            return true;
          }
        }
        return false;
      }
    }
