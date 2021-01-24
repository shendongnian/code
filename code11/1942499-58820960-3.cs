            internal void DrawBezierCurve(Pen pen, PaintEventArgs e)
            {
                LinePath = new GraphicsPath();
                var p1 = new Point(StartX, StartY); //starting point
                var p2 = new Point(FirstDipX, FirstDipY) //first control point
                var p3 = new Point(SecondDipX, SecondDipY); //second control point
                var p4 = new Point(EndX, EndY); //ending point
                LinePath.AddBezier(p1, p2, p3, p4);
                e.Graphics.DrawPath(pen, LinePath);
            }
