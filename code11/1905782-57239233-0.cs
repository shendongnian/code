    internal static FrameworkElement FindChildByName(DependencyObject startNode, string name)
    {
        int count = VisualTreeHelper.GetChildrenCount(startNode);
        for (int i = 0; i < count; i++)
        {
            DependencyObject current = VisualTreeHelper.GetChild(startNode, i);
    
            if (current is FrameworkElement frameworkElement)
            {
                if (frameworkElement.Name == name)
                    return frameworkElement;
            }
            var result = FindChildByName(current, name);
            if ( result != null)
            {
                return result;
            }
        }
        return null;
    }
