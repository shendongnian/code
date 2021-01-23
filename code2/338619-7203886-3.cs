    private void node_AfterCheck(object sender, TreeViewEventArgs e)
    {
       // The code only executes if the user caused the checked state to change.
       if(e.Action != TreeViewAction.Unknown)
       {
          if(e.Node.Nodes.Count > 0)
          {
             //Check whether that is a valid checkbox
             // If not you can uncheck it.
          }
       }
    }
