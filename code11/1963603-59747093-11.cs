    public static class MyExtensions
    {
      // Get item container of item from TreeView, TreeViewItem, ListView or any ItemsControl
      public static bool TryGetContainerOfChildItem<TItemContainer>(this ItemsControl itemsControl, object item, out TItemContainer itemContainer) 
      {
        itemContainer = null;
        foreach (object childItem in itemsControl.Items)
        {
          if (childItem == item)
          {
            itemContainer = itemsControl.ItemContainerGenerator.ContainerFromItem(item) as TreeViewItem;
            return true;
          }
          var childItemContainer = itemContainerGenerator.ContainerFromItem(childItem);
          if (childItemContainer is ItemsControl itemsControl && MyExtensions.TryGetContainerOfChildItem(
            itemsControl,
            item,
            out itemContainer))
          {
            return true;
          }
        }
        return false;
      }
    }
