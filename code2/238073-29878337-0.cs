       public void AddNodeAndChildNodesToList(TreeNode node)
        {
            listBox1.Items.Add(node.Text);    // Adding current nodename to ListBox     
            foreach (TreeNode actualNode in node.Nodes)
            {
                AddNodeAndChildNodesToList(actualNode); // recursive call
            }
        }
