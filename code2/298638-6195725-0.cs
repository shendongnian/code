    public static DependencyObject GetNextSibling(ItemsControl itemsControl, DependencyObject sibling)
    {
        var n = itemsControl.Items.Count;
        var foundSibling = false;
        for (int i = 0; i < n; i++)
        {
            var child = itemsControl.ItemContainerGenerator.ContainerFromIndex(i);
            if (foundSibling)
                return child;
            if (child == sibling)
                foundSibling = true;
        }
        return null;
    }
