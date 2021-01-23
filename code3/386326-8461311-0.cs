    void moveableStackPanel1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ReleaseMouseCapture();
        }
        void moveableStackPanel1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (IsEnabled && IsVisible)
                CaptureMouse();
        }
        void moveableStackPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseCaptured)
            {
                Point newLoc = e.GetPosition(null);
                Margin = new Thickness(newLoc.X, newLoc.Y, 0, 0);
            }
        } 
