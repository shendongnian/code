     private void treeView1_MouseDown(object sender, MouseEventArgs e)
     {
            TreeNode Node = treeView1.GetNodeAt(e.Location);
            if (Node != null && Node.Bounds.Contains(e.Location))
                treeView1.SelectedNode = Node;
            else
                treeView1.SelectedNode = null;
     } 
