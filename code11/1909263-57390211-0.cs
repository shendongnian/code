csharp
public MainPage()
{
    this.InitializeComponent();
    var items = new List<Item>();
    var rootItem = new Item();
    rootItem.Name = "Root Item";
    rootItem.Children.Add(new Item() { Name = "test child 1" });
    items.Add(rootItem);
    var treeView = new TreeView();
    foreach (var root in items)
    {
        var rootNode = new TreeViewNode() { Content = root.Name };
        if (root.Children.Count > 0)
        {
            foreach (var child in root.Children)
            {
                rootNode.Children.Add(new TreeViewNode() { Content = child.Name });
            }
        }
        treeView.RootNodes.Add(rootNode);
    }
    stackPanel.Children.Add(treeView);
}
Best regards.
