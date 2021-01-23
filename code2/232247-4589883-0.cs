    public static IEnumerable<DependencyObject> GetVisuals(this DependencyObject root)
    {
        int count = VisualTreeHelper.GetChildrenCount(root);
        for (int i = 0; i < count; i++)
        {
            var child = VisualTreeHelper.GetChild(root, i);
            yield return child;
            foreach (var descendants in child.GetVisuals())
            {
                yield return descendants;
            }
        }
    }
