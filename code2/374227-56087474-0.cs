    public static class TreeExtensions
    {
        public static IEnumerable<TreeNode> GetAncestors(this TreeNode node)
        {
            if (node == null)
                yield break;
            while ((node = node.Parent) != null)
                yield return node;
        }
    }
