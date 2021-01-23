    private void AdjustWindowSize()
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                System.Drawing.Rectangle r = Screen.GetWorkingArea(new System.Drawing.Point((int)this.Left, (int)this.Top));
                this.MaxWidth = r.Width;
                this.MaxHeight = r.Height;
                this.WindowState = WindowState.Maximized;
            }
        }
    
