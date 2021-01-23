    private DependencyObject GetVisualTreeRoot(DependencyObject control)
    {
        DependencyObject parent = VisualTreeHelper.GetParent(control);
        if (parent != null)
        {
            return GetVisualTreeRoot(parent);
        }
        else
        {
            return control;
        }
    }
