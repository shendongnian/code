    TreeView tr = new TreeView();
    
    private void Form1_Load(object sender, EventArgs e)
    {
        tr.AfterSelect += new TreeViewEventHandler(tr_AfterSelect);
    }
    
    void tr_AfterSelect(object sender, TreeViewEventArgs e)
    {
        TreeNode PrevNode = e.Node.PrevNode;
        TreeNode NextNode = e.Node.NextNode;
    }
