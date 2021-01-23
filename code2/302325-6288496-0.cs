    private void button3_Click(object sender, EventArgs e)
    {
        if (treeView1.SelectedNode != null)
            treeView1.SelectedNode.Remove();
       else
          Messagebox.Show ("Please select the node first");
    }
    
    private void button1_Click(object sender, EventArgs e)
        {
            TreeNode t;
            t = treeView1.Nodes.Add(textBox1.Text);
            treeView1.SelectedNode = t;
    
        }
