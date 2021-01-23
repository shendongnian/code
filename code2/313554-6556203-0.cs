    public class AccessibleTreeItem
    {
        public string name;
        public List<AccessibleTreeItem> children;
        public AccessibleTreeItem()
        {
            children = new List<AccessibleTreeItem>();
        }
        public static AccessibleTreeItem Find(AccessibleTreeItem node, string name)
        {
            if (node == null)
                return null;
            if (node.name == name)
                return node;
            foreach (var child in node.children)
            {
                var found = Find(child, name);
                if (found != null)
                    return found;
            }
            return null;
        }
    }
