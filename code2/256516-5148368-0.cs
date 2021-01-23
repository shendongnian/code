        public delegate void Del(TreeNode node);
        public window_main()
        {
            InitializeComponent();
            Thread t = new Thread(load_ad);
            t.Start();
        }
        private void addNode(TreeNode node)
        {
            treeViewObjects.Nodes.Add(node);
        }
        private void load_ad()
        {
            TreeNode root = new TreeNode(directoryEntry.Name.Replace("\\", ""));
            root.Tag = directoryEntry;
            Del del = addNode;
            treeViewObjects.Invoke(del, root);
            foreach (DirectoryEntry myChildDirectoryEntry in directoryEntry.Children)
            {
                TreeNode node = rec(myChildDirectoryEntry);
                treeViewObjects.Invoke(new Action(() =>
                {
                    root.Nodes.Add(node);
                }));
            }
        }
        private TreeNode rec(DirectoryEntry dir)
        {
            TreeNode node = new TreeNode(dir.Name.Replace("\\", ""));
            node.Tag = dir;
            foreach (DirectoryEntry myChildDirectoryEntry in dir.Children)
            {
                try
                {
                    node.Nodes.Add(rec(myChildDirectoryEntry));
                }
                catch
                {
                    TreeNode nodeChild = new TreeNode(dir.Name.Replace("\\", ""));
                    nodeChild.Tag = myChildDirectoryEntry;
                    node.Nodes.Add(nodeChild);
                }
            }
            return node;
        }
