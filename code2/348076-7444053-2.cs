    Bitmap bmp = new Bitmap(256, 256);
    protected override void OnPaint(PaintEventArgs e)
    {
      e.Graphics.DrawImage(bmp, new Point(0, 0));
    }
    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
      mouseDown = e.Location;
    }
    private void Form1_MouseUp(object sender, MouseEventArgs e)
    {
       mouseUp = e.Location;
       using (Graphics g = Graphics.FromImage(bmp))
       {
         g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
         g.DrawLine(Pens.Red, mouseDown.X, mouseDown.Y, mouseUp.X, mouseUp.Y);
       }
       this.Invalidate();           
    }
