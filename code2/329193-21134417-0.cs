    public string SelectedTreeExplorerPath { get; set; }
    private void GetSelectedTreeExplorerPath(TreeViewItem treeItem)
            {
                if (treeItem == null)
                    return;
                SelectedTreeExplorerPath = "";
                string temp1 = "";
                string temp2 = "";
                while (true)
                {
                    temp1 = treeItem.Header.ToString();
                    if (temp1.Contains(@"\"))
                    {
                        temp2 = "";
                    }
                    SelectedTreeExplorerPath = temp1 + temp2 + SelectedTreeExplorerPath;
                    if (treeItem.Parent.GetType().Equals(typeof(TreeView)))
                    {
                        break;
                    }
                    treeItem = ((TreeViewItem)treeItem.Parent);
                    temp2 = @"\";
                }
            }
