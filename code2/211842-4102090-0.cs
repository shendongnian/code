    protected void Page_Load(object sender, EventArgs e)
    {
      RemoveNodeRecurrently(TreeView1.Nodes, "Status");
    }
    
    private void RemoveNodeRecurrently(TreeNodeCollection childNodeCollection, string text)
    {
      foreach (TreeNode childNode in childNodeCollection)
      {
        if (childNode.ChildNodes.Count > 0)
          RemoveNodeRecurrently(childNode.ChildNodes, text);
    
        if (childNode.Text == text)
        {
          TreeNode parentNode = childNode.Parent;
          parentNode.ChildNodes.Remove(childNode);
          break;
        }
      }
    }
