    private void Invalidate(object sender, RoutedEventArgs e)
    {
        _payload.Timestamp = DateTime.Now.Add(TimeSpan.FromHours(1)).ToLongTimeString();
    
        Button b = sender as Button;
    
        //b.InvalidateProperty(Button.ContentProperty);
        this.InvalidateProperty(Button.ContentProperty, b);
    }
