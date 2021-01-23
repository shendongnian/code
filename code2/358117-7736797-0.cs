            private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            base.OnShown(e);
            int originalStyle = GetWindowLong(this.Handle, GWL.ExStyle);
            int wl = GetWindowLong(this.Handle, GWL.ExStyle);
            wl = wl | 0x80000 | 0x20;
            SetWindowLong(this.Handle, GWL.ExStyle, wl);
            int X = Cursor.Position.X;
            int Y = Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
            System.Threading.Thread.Sleep(50);
            SetWindowLong(this.Handle, GWL.ExStyle, originalStyle);
            this.TopMost = true;
        }
