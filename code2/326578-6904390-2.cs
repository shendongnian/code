    private void TemplateButton_Click(object sender, RoutedEventArgs e)
    {
        Button clickedButton = sender as Button;
        ListBoxItem listBoxItem = GetVisualParent<ListBoxItem>(clickedButton);
        if (listBoxItem != null)
        {
            listBoxItem.IsSelected = true;
        }
    }
    public static T GetVisualParent<T>(object childObject) where T : Visual
    {
        DependencyObject child = childObject as DependencyObject;
        // iteratively traverse the visual tree
        while ((child != null) && !(child is T))
        {
            child = VisualTreeHelper.GetParent(child);
        }
        return child as T;
    }
