    private void RemoveSelf(object sender, RoutedEventArgs e)
    {
        if (sender is UIElement element)
        {
            element.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            Canvas.Children.Remove(element);
        }
    }
