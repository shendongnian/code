      private void txtSerach_KeyUp(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Enter)
         {
            var searchFor = txtSerach.Text.Trim().ToUpper();
            if (searchFor != "")
            {
               if (treeView1.Nodes.Count > 0)
               {
                  if (SearchRecursive(treeView1.Nodes, searchFor))
                  {
                     treeView1.SelectedNode.Expand();
                     treeView1.Focus();
                  }
               }
            }
         }
      }
      private bool SearchRecursive(IEnumerable nodes, string searchFor)
      {
         foreach (TreeNode node in nodes)
         {
            if (node.Text.ToUpper().Contains(searchFor))
            {
               treeView1.SelectedNode = node;
               return true;
            }
            if (SearchRecursive(node.Nodes, searchFor))
               return true;
         }
         return false;
      }
