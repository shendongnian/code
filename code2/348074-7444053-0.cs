    private void DrawLine(Graphics g)
    {
         System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Red);
        
         g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
         g.DrawLine(myPen, mouseDown.X, mouseDown.Y, mouseUp.X, mouseUp.Y);
         myPen.Dispose();
    }
    protected override void OnPaint(PaintEventArgs e)
    {
         DrawLine(e.Graphics);
    }
