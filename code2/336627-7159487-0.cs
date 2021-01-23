    StringBuilder sb = new StringBuilder(); 
    
    foreach (TreeNode t in treeView1.Nodes)
    {
         if (t.Checked == true)
    
         sb.Append(t.Text + Environment.NewLine);
    
         if (t.Nodes.Count > 0)
    
         {
    
              foreach (TreeNode tt in t.Nodes)
    
              {
    
                   if (tt.Checked == true)
    
                        sb.Append(tt.Text + Environment.NewLine);
              }
        }
    
    }
    
    MessageBox.Show(sb.ToString(), "Checked Nodes")
