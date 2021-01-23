    //Remove Duplicated Nodes
          List<TreeNode> oldPinGrpNodes = new List<TreeNode>();
          Dictionary<string, TreeNode> newPinGrpNodes = new Dictionary<string, TreeNode>();
          TreeNode tempNode;
    
    
          foreach (TreeNode node in tvPinGroups.Nodes)
          {
            oldPinGrpNodes.Add(node);
          }
    
          foreach (TreeNode node in oldPinGrpNodes)
          {
            if (newPinGrpNodes.ContainsKey(node.Text)) continue; //this does not compile!
            //How to do a check in the IF statement above?
    
            //Continue with adding the unique pins to the newList
            // do something like
            newPinGrpNodes.Add(node.Text, node);
          }
