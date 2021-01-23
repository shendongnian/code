    //get a list of selected notes after submit button is clicked
     protected void submitBtn_Click(object sender, EventArgs e)
     {
               if (this.tree.CheckedNodes.Count > 0)
                {
                    // Iterate through the CheckedNodes collection and display the selected nodes.
                    foreach (TreeNode node in tree.CheckedNodes)
                    {
                       Response.Write(node.Value + "<br />"); 
                    }
                }
        
                else
                {
                    Response.Write("No node selected.");
        
                }
    }
