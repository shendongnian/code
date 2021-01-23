    //Remove Duplicated Nodes
          List<TreeNode> oldPinGrpNodes = new List<TreeNode>();
          List<TreeNode> newPinGrpNodes = new List<TreeNode>();
          TreeNode tempNode;
    
    
          foreach (TreeNode node in tvPinGroups.Nodes)
          {
            oldPinGrpNodes.Add(node);
          }
    
          var newPinGrpNodesLookup = newPinGrpNodes.ToLookup(x => x.Text, x => x);
    
          foreach (TreeNode node in oldPinGrpNodes)
          {
            if (newPinGrpNodesLookup.Contains(node.Text)) continue; //this does not compile!
            //How to do a check in the IF statement above?
    
            //Continue with adding the unique pins to the newList
          }
