    /// <summary>
    /// Helper function for searching all controls of the specified type.
    /// </summary>
    /// <typeparam name="T">Type of control.</typeparam>
    /// <param name="depObj">Where to look for controls.</param>
    /// <returns>Enumerable list of controls.</returns>
    public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj)
        where T : DependencyObject
    {
        if (depObj != null)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                if (child != null && child is T)
                {
                    yield return (T)child;
                }
    
                foreach (T childOfChild in FindVisualChildren<T>(child))
                {
                    yield return childOfChild;
                }
            }
        }
    }
