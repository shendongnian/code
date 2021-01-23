     private void HandleOnTreeViewAfterCheck(Object sender, 
                TreeViewEventArgs e)
            {
                Boolean isChecked = e.Node.Checked;
    
                foreach (TreeNode item in e.Node.Nodes)
                {
                    item.Checked = isChecked;
                }
            }
