    public IEnumerable<TChildType> FindChildren<TChildType>(DependencyObject parent)
    {
        var count = VisualTreeHelper.GetChildrenCount(parent);
        for (int i = 0; i < count; i++)
        {
            var child = VisualTreeHelper.GetChild(parent, i);
            if (child is TChildType typedChild)
            {
                yield return typedChild;
            }
    
            foreach (var nestedChild in FindChildren<TChildType>(child))
            {
                yield return nestedChild;
            }
        }
    }
