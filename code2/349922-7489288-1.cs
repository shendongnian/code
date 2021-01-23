      public void PopulateTreeView(string values, TreeNode parentNode )
      {
          string nodeValue = values;
          string additionalData = values.Substring(value.Length - (value.Length - 2));
          try
          {
             if (!string.IsNullOrEmpty(nodeValue))
             {
                TreeNode myNode = new TreeNode(nodeValue);
                parentNode.Nodes.Add(myNode);
                PopulateTreeView(additionalData, myNode);
             }
          } catch ( UnauthorizedAccessException ) {
            parentNode.Nodes.Add( "Access denied" );
          } // end catch
      }
