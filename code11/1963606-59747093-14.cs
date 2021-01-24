    public static class MyExtensions
    {
      // Get item container of item from TreeView, TreeViewItem, ListView or any ItemsControl
      public static bool TryGetContainerOfChildItem<TItemContainer>(this ItemsControl itemsControl, object item, out TItemContainer itemContainer) where TItemContainer : DependencyObject
      {
        itemContainer = null;
        foreach (object childItem in itemsControl.Items)
        {
          if (childItem == item)
          {
            itemContainer = (TItemContainer) itemsControl.ItemContainerGenerator.ContainerFromItem(item);
            return true;
          }
          DependencyObject childItemContainer = itemsControl.ItemContainerGenerator.ContainerFromItem(childItem);
          if (childItemContainer is ItemsControl childItemsControl && childItemsControl.TryGetContainerOfChildItem(item, out itemContainer))
          {
            return true;
          }
        }
        return false;
      }
    }
