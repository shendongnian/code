    protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                Graphics g;
    
                g = CreateGraphics(); // or e.Graphics;
    
                Pen myPen = new Pen(Color.Red);
                myPen.Width = 30;
                g.DrawLine(myPen, 30, 30, 45, 65);
    
                g.DrawLine(myPen, 1, 1, 45, 65);
            }
