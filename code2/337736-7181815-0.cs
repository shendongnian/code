    private void StreamingWindow_MouseMove(object sender, MouseEventArgs e)
    {       
      if (e.Button == MouseButtons.Left)
      {
        // Draws the rectangle as the mouse moves
        rect = new Rectangle(rect.Left, rect.Top, Math.Min(e.X - rect.Left, pictureBox1.ClientRectangle.Width - rect.Left), Math.Min(e.Y - rect.Top, pictureBox1.ClientRectangle.Height - rect.Top));
      }
      this.Invalidate();     
    }
