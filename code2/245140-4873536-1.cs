    private void picCanvas_Paint(object sender, PaintEventArgs e)
    {
      if (_drag)         
      {
        using (Pen pen = new Pen(Color.White, 2))
        {
          e.Graphics.DrawEllipse(pen, pos.X, pos.Y, 10, 10);
        }
      }
    }
