    public static class TreeViewItemExtensions
    {
        public static int GetDepth(this TreeViewItem item)
        {
            DependencyObject target = item;
            var depth = 0;
            while (target != null)
            {
                if (target is TreeView)
                    return depth;
                if (target is TreeViewItem)
                    depth++;
                target = VisualTreeHelper.GetParent(target);
            }
            return 0;
        }
    }
