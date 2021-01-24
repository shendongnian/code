    public static bool IsTreeContains(Node node, string itemName)
    {
        if (node.Name == itemName)
            return true;
        foreach (var n in node.Nodes)
        {
            if(IsTreeContains(n, itemName))
                return true;          
        }
        
        return false;
    }
