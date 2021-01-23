    private void Form_Load(object sender, EventArgs e)
    {
        treeView.Nodes.Add(GetDirectoryNodes(@"C:\TEST", new string[] { @"C:\TeST\C", @"C:\TEST\E" }));
    }
    private static TreeNode GetDirectoryNodes(string path, string[] exclusions)
    {
        var node = new TreeNode(Path.GetFileName(path));
        var subDirs = (from d in Directory.GetDirectories(path)
                       where !exclusions.Contains(d,StringComparer.CurrentCultureIgnoreCase)
                       select GetDirectoryNodes(d,exclusions)).ToArray();
        node.Nodes.AddRange(subDirs);
        return node;
    }
