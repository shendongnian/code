    void ExecuteOnEachNode(TreeView tree, Action<TreeViewItem> func) // Executes 'func' on each item with it as parameter
    {
        foreach (TreeViewItem item in tree.Items)
        {
            func(item);
    
            foreach (TreeViewItem subitem in item.Items)
            {
                ExecuteOnEachNode(item, func); // Trasvel over current item children
            }
        }
    }
    ExecuteOnEachNode(item => MessageBox.Show(item.Header.ToString()));
