    //...
    string path = GetPath(treeView1.Nodes[0].Nodes[0].Nodes[1].Nodes[0]);
    // now path is "treeView.Nodes[0].Nodes[0].Nodes[1].Nodes[0]"
    //...
    string GetPath(TreeNode node) {
        int index;
        Stack<string> stack = new Stack<string>();
        while(node != null) {
            if(node.Parent != null) {
                index = node.Parent.Nodes.IndexOf(node);
                stack.Push(string.Format("Nodes[{0}]", index));
            }
            else {
                index = node.TreeView.Nodes.IndexOf(node);
                stack.Push(string.Format("treeView.Nodes[{0}]", index));
            }
            node = node.Parent;
        }
        return string.Join(".", stack.ToArray());
    }
