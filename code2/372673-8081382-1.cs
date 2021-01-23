    private void ResetTreeViewColors() { 
        foreach (Control tvc in this.Controls) { 
            if (tvc is TreeView) {
                TreeView tv = (TreeView)tvc;
                foreach(TreeNode tn in tv.Nodes) { 
                    tn.BackColor = Color.White; 
                    tn.ForeColor = Color.Black; 
                }
            } 
        } 
    } 
