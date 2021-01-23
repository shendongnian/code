    private void DrawLine(Graphics g)
    {
       using (Pen myPen = new Pen(System.Drawing.Color.Red))
       { 
         g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
         g.DrawLine(myPen, mouseDown.X, mouseDown.Y, mouseUp.X, mouseUp.Y);
       }
    }
    protected override void OnPaint(PaintEventArgs e)
    {
       DrawLine(e.Graphics);
    }
    private void Form1_MouseUp(object sender, MouseEventArgs e)
    {
       mouseUp = e.Location;
       this.Invalidate();           
    }
