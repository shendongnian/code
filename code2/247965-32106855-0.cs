        public bool IsFullscreen = false;
        public WindowState lastWindowState;
        private void player_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (IsFullscreen)
            {
                this.WindowStyle = WindowStyle.SingleBorderWindow;
                this.WindowState = lastWindowState;
                IsFullscreen = false;
            }
            else
            {
                lastWindowState = this.WindowState;
                
                this.WindowStyle = WindowStyle.None;
                if (this.WindowState == WindowState.Maximized)
                    this.WindowState = WindowState.Minimized;
                this.WindowState = WindowState.Maximized;
                IsFullscreen = true;
            }
        }
