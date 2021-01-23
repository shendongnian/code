    private void Form_Load(object sender, EventArgs e)
    {
        treeView.Nodes.Add(GetDirectoryNodes(@"C:\TEST"));
    }
    private static TreeNode GetDirectoryNodes(string path)
    {
        var node = new TreeNode(path);
        var subDirs = Directory.GetDirectories(path).Select(d => GetDirectoryNodes(d)).ToArray();
        node.Nodes.AddRange(subDirs);
        return node;
    }
