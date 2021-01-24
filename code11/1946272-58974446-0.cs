csharp
public class PathDisplay
{
    public string DisplayText { get; set; }
    public string Path { get; set; }
    public PathDisplay(){ }
    public PathDisplay(string d, string p)
    {
        DisplayText = d;
        Path = p;
    }
    public override string ToString()
    {
        return DisplayText;
    }
}
2. Create a recursive method for detecting the same node as `subPathAgg` (the `Find` method is no longer available in `TreeView`)
csharp
private IEnumerable<TreeViewNode> GetSameNodes(IList<TreeViewNode> nodes, string path)
{
    foreach (var node in nodes)
    {
        var content = node.Content as PathDisplay;
        if (content?.Path == path)
        {
            yield return node;
        }
        else
        {
            if (node.Children.Count > 0)
            {
                foreach (var item in GetSameNodes(node.Children,path))
                {
                    yield return item;
                }
            }
        }
    }
}
3. Rewrite the `PopulateTreeView` method. In UWP, many class names and methods have changed.
csharp
private void PopulateTreeView(TreeView treeView, string[] paths, char pathSeparator)
{
    TreeViewNode lastNode = null;
    string subPathAgg;
    long count = 0;
    foreach (string path in paths)
    {
        subPathAgg = string.Empty;
        foreach (string subPath in path.Split(pathSeparator))
        {
            subPathAgg += subPath + pathSeparator;
            var displayModel = new PathDisplay(subPath, subPathAgg);
            TreeViewNode[] nodes = GetSameNodes(treeView.RootNodes,subPathAgg).ToArray();
            if (nodes.Length == 0)
            {
                if (lastNode == null)
                {
                    lastNode = new TreeViewNode() { Content = displayModel };
                    treeView.RootNodes.Add(lastNode);
                }
                else
                {
                    var node = new TreeViewNode() { Content = displayModel };
                    lastNode.Children.Add(node);
                    lastNode = node;
                }
                count++;
            }
            else
            {
                lastNode = nodes[0];
            }
        }
        lastNode = null; // This is the place code was changed
    }
}
So that we can use it
**Xaml**
xml
<controls:TreeView x:Name="TestTreeView"
          />
**Xaml.cs**
csharp
public TreeViewPage()
{
    this.InitializeComponent();
    PopulateTreeView(TestTreeView, new string[]{
        @"C:\Users\User\Documents\Test1.txt",
        @"C:\Users\User\Documents\Test2.txt",
        @"C:\Users\User\Documents\folder\Test1.txt"
    }, '\\');
}
it looks like this:
![e34da227-e5a6-417c-b976-bb6dc4f3109b.png](https://storage.live.com/items/51816931BAB0F7A8!14059?authkey=AO7QXpgYo7-5DUU)
---
The code can be rewritten this way, but I recommend the collection binding in the [document](https://docs.microsoft.com/en-us/windows/uwp/design/controls-and-patterns/tree-view#tree-view-node-content), which is more conducive to later maintenance.
Best regards.
