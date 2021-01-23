    public static string GetPath(this XElement node)
    {
        string path = node.Name.ToString();
        XElement currentNode = node;
        while (currentNode.Parent != null)
        {
            currentNode = currentNode.Parent;
            path = currentNode.Name.ToString() + @"\" + path;
        }
        return path;
    }
    XElement node = ..
    string path = node.GetPath();
