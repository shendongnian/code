        private double LastHeight, LastWidth;
        private System.Windows.WindowState LastState;
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F11)
            {
                if (WindowStyle != WindowStyle.None)
                {
                    LastHeight = Height;
                    LastWidth = Width;
                    LastState = WindowState;
                    Topmost = true;
                    Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
                    Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
                    Top = 0;
                    Left = 0;
                    WindowState = System.Windows.WindowState.Normal;
                    WindowStyle = WindowStyle.None;
                    ResizeMode = System.Windows.ResizeMode.NoResize;
                }
                else
                {
                    WindowStyle = WindowStyle.SingleBorderWindow;
                    WindowState = LastState; ;
                    ResizeMode = ResizeMode.CanResizeWithGrip;
                    Topmost = false;
                    Width = LastWidth;
                    Height = LastHeight;
                }
            }
        }
