    void Recurse(string path, TreeNode parentNode)
    {
        DirectoryInfo info = new DirectoryInfo(path);
        TreeNode node = new TreeNode(info.Name);
        if (parentNode == null)
            MailTree.Nodes.Add(node);
        else
            parentNode.Nodes.Add(node);
        string[] sub = Directory.GetDirectories(path);
        if (sub.Length != 0)
        {
            foreach(string i in sub)
            {       
                Recurse(i, node);                  
            }
        }   
    }
