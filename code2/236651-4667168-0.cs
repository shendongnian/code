    public static IEnumerable<T> FindVisualChildren<T>
    (DependencyObject depObj, string childName) where T : DependencyObject
    {
        
        if (depObj != null)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
    
                DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                var frameworkElement = child as FrameworkElement;
                if (child != null && frameworkElement.Name == childName)
                {
                    yield return (T)child;
                }
    
                foreach (T childOfChild in FindVisualChildren<T>(child, childName))
                {
                    yield return childOfChild;
                }
            }
         }
    }
