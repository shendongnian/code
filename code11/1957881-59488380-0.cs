        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            GraphicsPath gPath;
            Pen gPen;
            gPen = new Pen(System.Drawing.SystemColors.ControlText);
            gPath = new GraphicsPath();
            gPath.AddLine(20, 10, 30, 20);
            gPath.CloseFigure();
            gPath.AddLine(20, 20, 30, 10);
            gPath.CloseFigure();
            e.Graphics.DrawPath(gPen, gPath);
        }
