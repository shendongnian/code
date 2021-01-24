 public void SelectNodeById(TreeView Tree)
        {
            var item = findItemById(Tree, "uid");
        }
        private static object findItemById(TreeView Tree, string uid)
        {
            foreach (var item in Tree.Items)
            {
                //every item in your tree is a dockpanel
                var d = item as DockPanel;
                //the first item has a uid
                if (d.Children.Count > 0 && d.Children[0].Uid == uid)
                    return item;
            }
            return null;
        }
In order to change the item's property `IsExpanded` to true, you should change it to  a `TreeViewItem`.
Then you can do something like this:
var item = new TreeViewItem();
item.IsExpanded = true;
item.IsSelected = true;
