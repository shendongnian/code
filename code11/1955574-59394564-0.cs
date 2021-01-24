    private void OnLostFocus(object sender, RoutedEventArgs e)
    {
        Debug.WriteLine("OnLostFocus");
        this.Focus(FocusState.Programmatic);
    }
