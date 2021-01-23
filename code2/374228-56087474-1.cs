    public static IEnumerable<T> GetAncestors<T>(T item, Func<T, T> getParent)
    {
        if (item == null)
            yield break;
        while ((item = getParent(item)) != null)
            yield return item;
    }
    public static IEnumerable<TreeNode> GetAncestors(this TreeNode node) => GetAncestors(node, x => x.Parent);
    public static IEnumerable<Control> GetAncestors(this Control control) => GetAncestors(control, x => x.Parent);
