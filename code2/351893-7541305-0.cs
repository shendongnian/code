    private void button1_Click(object sender, EventArgs e)
    {
      List<string> listPath = new List<string>();
      GetAllPaths(treeView1.Nodes[0], listPath);
      StringBuilder sb = new StringBuilder();
      foreach (string item in listPath)
        sb.AppendLine(item);
      MessageBox.Show(sb.ToString());
    }
    private void GetAllPaths(TreeNode startNode, List<string> listPath)
    {
      listPath.Add(startNode.FullPath);
      foreach (TreeNode tn in startNode.Nodes)
        GetAllPaths(tn, listPath);
    }
