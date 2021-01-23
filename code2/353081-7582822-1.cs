    public class BindableTreeView : TreeView
    {
        protected override DependencyObject GetContainerForItemOverride()
        {
            var itm = new BindableTreeViewItem();
            itm.SetBinding(TreeViewItem.IsExpandedProperty, new Binding("IsExpanded") { Mode = BindingMode.TwoWay });
            return itm;
        }
    }
    public class BindableTreeViewItem : TreeViewItem
    {
        protected override DependencyObject GetContainerForItemOverride()
        {
            var itm = new BindableTreeViewItem();
            itm.SetBinding(TreeViewItem.IsExpandedProperty, new Binding("IsExpanded") { Mode = BindingMode.TwoWay });
            return itm;
        }
    }
