    private void ControlX_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        // Get the relative position of the element
    	Point point = e.GetPosition(sender as UIElement);
        if (point.X > control.Width/2)
        {
            if (point.Y > control.Height/2)
            {
                // You are in the bottom right quarter
            }
            else
            {
                // You are in the top right quarter
            }
        }
        else
        {
            if (point.Y > control.Height/2)
            {
                // You are in the bottom left quarter
            }
            else
            {
                // You are in the top left quarter
            }
        }
    }
