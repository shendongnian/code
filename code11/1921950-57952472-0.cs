    private void PopulateTreeView(string path)
    {
      TreeNode rootNode;
      {
        DirectoryInfo info = new DirectoryInfo(path);
        if (info.Exists)
        {
          treeView.Nodes.Clear();
          rootNode = new TreeNode(info.Name);
          rootNode.Tag = info;
          GetDirectories(info.GetDirectories(), rootNode);
          treeView.Nodes.Add(rootNode);
          LoadFiles(info.FullName, rootNode);
        }
        else
          MessageBox.Show("Please select a path");
      }
    }
     private void ListView_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      if (listView.SelectedItems.Count > 0)
      {
        if (!string.IsNullOrEmpty(listView.SelectedItems[0].Text))
        {
          string SelectedPath_Combine = @"" + SelectedPath + "\\" + listView.SelectedItems[0].Text + "";
          FileAttributes attr = File.GetAttributes(@"" + SelectedPath_Combine + "");
          if ((attr & FileAttributes.Directory) != FileAttributes.Directory)
          {
            System.Diagnostics.Process.Start(SelectedPath_Combine);
          }
          else if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
          {
            PopulateTreeView(SelectedPath_Combine);
          }
        }
      }
    }
