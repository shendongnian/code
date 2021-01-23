    private bool latch;
    void TreeNode_AfterCheck(object sender, TreeViewEventArgs e) {
      if (latch)
          return;
    
      latch = true;
    
      try
      {
          if (0 < e.Node.Nodes.Count) {
            if (e.Node.Checked) {
              e.Node.Expand();
              TreeNodes_SetChecksTo(e.Node, true);
            } else {
              if (!TreeNode_SomethingChecked(e.Node)) {
                e.Node.Collapse(false);
              }
            }
          }
      }
      finally
      {
          latch = false;
      }
    }
