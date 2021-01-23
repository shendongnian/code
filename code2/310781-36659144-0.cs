    private void YourTextBlock_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        YourTextBox.Visibility = Visibility.Visible;
        YourTextBox.Focus();
        CaptureMouse();
        Mouse.AddPreviewMouseDownOutsideCapturedElementHandler(this, OnMouseDownOutsideElement);
    }
    
    private void OnMouseDownOutsideElement(object sender, MouseButtonEventArgs e)
    {
        Mouse.RemovePreviewMouseDownOutsideCapturedElementHandler(this, OnMouseDownOutsideElement);
        ReleaseMouseCapture();
        YourTextBox.Visibility = Visibility.Hidden;
    }
