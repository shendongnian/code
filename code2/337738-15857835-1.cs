    private void StreamingWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.X < StreamingWindow.Width && Math.Abs(e.Y) < StreamingWindow.Height)
                    // Draws the rectangle as the mouse moves
                    rect = new Rectangle(rect.Left, rect.Top, e.X - rect.Left, e.Y -rect.Top);
            }
            this.Invalidate();
        }
