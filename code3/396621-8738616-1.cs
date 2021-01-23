    public Form1()
    {
       InitializeComponent();
       tree.SelectedNode = tree.Nodes.Add("Hello", "Hello");
    }
    private void button1_Click(object sender, EventArgs e)
    {
        tree.LabelEdit = true;
        TreeNode node = new TreeNode("New Folder");
        tree.SelectedNode.Nodes.Add(node);
        tree.SelectedNode.Expand();
        node.BeginEdit();
    }
