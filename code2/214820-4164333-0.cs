    private void Form1_Activated(object sender, EventArgs e)
        {           
            treeView1.ExpandAll();
            while (true)
            {
                if (treeView1.SelectedNode.Text.Contains(".txt"))
                {
                    treeView1.Focus();
                    return;
                }
                treeView1.SelectedNode = treeView1.SelectedNode.NextVisibleNode;
            }            
        }
