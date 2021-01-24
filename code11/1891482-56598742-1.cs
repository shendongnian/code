    public class MyExtendedTreeView : TreeView
    {    
      protected override bool IsItemItsOwnContainerOverride(object item)
      {
        return (item is RadTreeViewItem);
      }
    
      protected override DependencyObject GetContainerForItemOverride()
      {
        return new RadTreeViewItem();
      }
    }
