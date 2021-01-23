    private void IterateTreeNodes( TreeNode originalNode, TreeNode rootNode )
    {
      foreach ( TreeNode childNode in originalNode.Nodes )
      {
        TreeNode newNode = new TreeNode( childNode.Text );
        newNode.Tag = childNode.Tag;
        treeView2.SelectedNode = rootNode;
        treeView2.SelectedNode.Nodes.Add( newNode );
        IterateTreeNodes( childNode, newNode );
      }
    }
    
    // copy nodes from treeView1 to treeView2
    private void button1_Click( object sender, EventArgs e )
    {
      foreach ( TreeNode originalNode in treeView1.Nodes )
      {
        TreeNode newNode = new TreeNode( originalNode.Text );
        newNode.Tag = originalNode.Tag;
        treeView2.Nodes.Add( newNode );
        IterateTreeNodes( originalNode, newNode );
      }
    }
