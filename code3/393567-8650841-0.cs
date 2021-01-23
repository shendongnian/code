    private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left)
        {
            switch (WindowState)
            {
                case (WindowState.Maximized):
                {
                    ResizeMode = ResizeMode.CanResize; 
                    WindowStyle = WindowStyle.SingleBorderWindow;
                    WindowState = WindowState.Normal;
                    break;
                }
                case (WindowState.Normal):
                {
                    ResizeMode = ResizeMode.NoResize;
                    WindowStyle = WindowStyle.None;
                    WindowState = WindowState.Maximized;
                    break;
                }
            }
        }
    }
