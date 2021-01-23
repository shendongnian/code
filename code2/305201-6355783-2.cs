    void tr_AfterSelect(object sender, TreeViewEventArgs e)
    {
        TreeNode NextNode;
        if (e.Node.Nodes.Count == 0)
        {
            NextNode = e.Node.NextNode;
        }
        else 
        {
            NextNode = e.Node.Nodes[0]; 
        }
    }
