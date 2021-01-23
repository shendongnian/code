    // Find the node you want to have as parent.
    var parentNode = myTreeView.Items.Cast<TreeViewItem>().FirstOrDefault(item => item.Header = "Parent Node");
    if (parentNode != null)
    {
        var newNode = new TreeViewItem
        {
            Header = "New Node"
        };
        parentNode.Items.Add(newNode);
    }
