    var item = treeView1.Items.Cast<TreeViewItem>().FirstOrDefault(item => item.Header.ToString() == ingredient);
    if (item != null)
    {
        TreeViewItem childItem = new TreeViewItem { Header = cookingSuggestion };
        item.Items.Add(childItem);    
    }
