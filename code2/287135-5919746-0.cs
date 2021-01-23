    public Form1()
        {
            InitializeComponent();
            TreeNode n1;
            TreeNode n2;
            TreeNode n3;
            n1 = treeView1.Nodes.Add("A");
            n2 = n1.Nodes.Add("B");
            n3 = n2.Nodes.Add("C");
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
        }
