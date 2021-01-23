    private void StackPanel_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            TextBox s = e.Source as TextBox;
            if (s != null)
            {
                s.MoveFocus(new TraversalRequest( FocusNavigationDirection.Next));
            }
    
            e.Handled = true;
        }
    }
