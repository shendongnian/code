    private void OnCloseTabItemExecute(object sender, ExecutedRoutedEventArgs e)
    {
        DependencyObject element = e.Parameter as DependencyObject;
        TabItem tabItem = GetVisualParent<TabItem>(element);
        //...
    }
    public static T GetVisualParent<T>(object childObject) where T : FrameworkElement
    {
        DependencyObject child = childObject as DependencyObject;
        while ((child != null) && !(child is T))
        {
            child = VisualTreeHelper.GetParent(child);
        }
        return child as T;
    }
    
