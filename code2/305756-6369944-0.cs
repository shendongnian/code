    private bool IsDragging = false;
    private System.Windows.Point LastPosition;
    private void MyImage_MouseDown(object sender, MouseButtonEventArgs e)
    {
        // Get the right MyImage
        Image MyImage = sender as Image;
        
        // Capture the mouse
        if (!MyImage.IsMouseCaptured)
        {
            MyImage.CaptureMouse();
        }
        // Turn the drag mode on
        IsDragging = true;
        // Set the current mouse position to the last position before the mouse was moved
        LastPosition = e.GetPosition(SelectionCanvas);
        // Set this event to handled
        e.Handled = true;
    }
    private void MyImage_MouseUp(object sender, MouseButtonEventArgs e)
    {
        // Get the right MyImage
        Image MyImage = sender as Image;
        
        // Release the mouse
        if (MyImage.IsMouseCaptured)
        {
            MyImage.ReleaseMouseCapture();
        }
        // Turn the drag mode off
        IsDragging = false;
        // Set this event to handled
        e.Handled = true;
    }
    private void MyImage_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
    {
        // Get the right MyImage
        Image MyImage = sender as Image;
        // Move the MyImage only when the drag move mode is on
        if (IsDragging)
        {
            // Calculate the offset of the mouse movement
            double xOffset = LastPosition.X - e.GetPosition(SelectionCanvas).X;
            double yOffset = LastPosition.Y - e.GetPosition(SelectionCanvas).Y;
            // Move the MyImage
            Canvas.SetLeft(MyImage, (Canvas.GetLeft(MyImage) - xOffset >= 0.0) && (Canvas.GetLeft(MyImage) + MyImage.Width - xOffset <= SelectionCanvas.ActualWidth) ? Canvas.GetLeft(MyImage) - xOffset : Canvas.GetLeft(MyImage));
            Canvas.SetTop(MyImage, (Canvas.GetTop(MyImage) - yOffset >= 0.0) && (Canvas.GetTop(MyImage) + MyImage.Height - yOffset <= SelectionCanvas.ActualHeight) ? Canvas.GetTop(MyImage) - yOffset : Canvas.GetTop(MyImage));
            // Set the current mouse position as the last position for next mouse movement
            LastPosition = e.GetPosition(SelectionCanvas);
        }
    }
