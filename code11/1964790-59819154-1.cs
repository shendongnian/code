    private void mOpenDetailButton_Click(object sender, RoutedEventArgs e)
    {
        UIElement mybutton = sender as UIElement;
        StackPanel stackPanel = FindParent<StackPanel>(mybutton);
        object storyvalue = null;
        stackPanel?.Resources.TryGetValue("OpenStoryboard", out storyvalue);
        Storyboard storyboard = value as Storyboard;
        storyboard?.Begin();
    }
    
    public static T FindParent<T>(DependencyObject element)
                where T : DependencyObject
    {
        while (element != null)
        {
            DependencyObject parent = VisualTreeHelper.GetParent(element);
            T candidate = parent as T;
            if (candidate != null)
            {
                return candidate;
            }
            element = parent;
        }
        return default(T);
    }
