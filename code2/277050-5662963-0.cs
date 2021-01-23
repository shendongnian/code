    ObservableCollection<TreeViewItem> helper = new ObservableCollection<TreeViewItem>();
    foreach(TreeViewItem item in treeView1.SelectedItem.Items)
    {
      helper.Add(item);
    }
    
    foreach(TreeViewItem item in helper)
    {
      treeView1.SelectedItem.Items.Remove(item);
    }
