        public Form1()
        {
            InitializeComponent();
            FindNode(treeView1.Nodes, ".txt");
            this.ActiveControl = treeView1;
        }
        public void FindNode(TreeNodeCollection nodeCollection, string TextToFind)
        {
            foreach (TreeNode node in nodeCollection)
            {
                if (node.Text.Contains(TextToFind))
                {
                    treeView1.SelectedNode = node;
                    TreeNode parentNode = node.Parent;
                    while (parentNode != null)
                    {
                        parentNode.Expand();
                        parentNode = parentNode.Parent;
                    }
                    break;
                }
                FindNode(node.Nodes, TextToFind);
            }
        }
