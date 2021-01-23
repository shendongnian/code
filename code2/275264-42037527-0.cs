         public void RootCopy(TreeView treeview1, TreeView treeview2)
        {
            TreeNode newNode;
            foreach (TreeNode tnode in treeview1.Nodes)
            {
                newNode = new TreeNode(tnode.Text);
                treeview2.Nodes.Add(newNode);
                if (tnode.Nodes.Count != 0)
                {
                    int _1index = tnode.Index;
                    ChildsCopyLevel2(_1index, treeview1, treeview2);
                }
            }
        }
        public void ChildsCopyLevel2(int index1, TreeView TV1, TreeView TV2)
        {
            foreach (TreeNode Tnode in TV1.Nodes[index1].Nodes)
            {
                string Childtext = Tnode.Text;
                TV2.Nodes[index1].Nodes.Add(Childtext);
                if (Tnode.Nodes.Count != 0)
                {// ChildsCopyLevel3(Tnode.Nodes.Count, TV1, TV2);
                    int _2index = Tnode.Index;
                    ChildsCopyLevel3(index1, _2index, TV1, TV2);
                }
            }
        }
        public void ChildsCopyLevel3(int index1, int index2, TreeView TV1, TreeView TV2)
        {
            foreach (TreeNode Tnode in TV1.Nodes[index1].Nodes[index2].Nodes)
            {
                string Childtext = Tnode.Text;
                TV2.Nodes[index1].Nodes[index2].Nodes.Add(Childtext);
            }
        }
