     private void TreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode newSelected = e.Node;
            DirectoryInfo _NewPath = (DirectoryInfo)newSelected.Tag;
            if(_NewPath != null && !string.IsNullOrWhiteSpace(_NewPath.FullName))
            {
                webBrowser.Url = new Uri(_NewPath.FullName);
            }
        }
