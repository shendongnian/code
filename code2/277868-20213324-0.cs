    private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
    {  
       Label1.Text = "";
       if(e.Node.Parent!= null && 
         e.Node.Parent.GetType() == typeof(TreeNode) )
       {
          Label1.Text = "Parent: " + e.Node.Parent.Text + "\n"
             + "Index Position: " + e.Node.Parent.Index.ToString();
       }
       else
       {
          Label1.Text = "This is parent node.";
       }
    }
