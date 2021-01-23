    private bool updatingChecks;
    
    void TreeNode_AfterCheck(object sender, TreeViewEventArgs e) {
      if (updatingChecks) return;
      updatingChecks = true;
      try {
        // etc..
      }
      finally {
        updatingChecks = false;
      }
    }
