    class canvas : Control
        {
    
            PointF mouseDown;
    
            float newX;
            float newY;
            float zoomFactor = 1F;
    
    
            public canvas()
            {
                this.DoubleBuffered = true;
                mouseDown = new PointF(0F, 0F);
            }
    
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                Graphics dc = e.Graphics;
    
                dc.SmoothingMode = SmoothingMode.AntiAlias;
    
                Color gridColor = Color.FromArgb(230, 230, 230);
                Pen gridPen = new Pen(gridColor, 1);
    
                float offX = (float)((Math.Sqrt(Math.Pow(newX, 2)) % (30 * zoomFactor)));
                float offY = (float)((Math.Sqrt(Math.Pow(newY, 2)) % (30 * zoomFactor)));
    
                for (float y = offY; y < this.Height; y = y + 30 * zoomFactor)
                {
                    dc.DrawLine(gridPen, 0, y, this.Width, y);
                }
                for (float x = offX; x < this.Width; x = x + 30 * zoomFactor)
                {
                    dc.DrawLine(gridPen, x, 0, x, this.Height);
                }
    
                dc.TranslateTransform(newX, newY);
                dc.ScaleTransform(zoomFactor, zoomFactor, MatrixOrder.Prepend);
    
                float XPosition = 10;
                float YPosition = 10;
                float CornerRadius = 5;
                float Width = 50;
                float Height = 50;
    
                Color BoxColor = Color.FromArgb(0, 0, 0);
                Pen BoxPen = new Pen(BoxColor, 2);
    
                GraphicsPath Path = new GraphicsPath();
    
                Path.AddLine(XPosition + CornerRadius, YPosition, XPosition + Width - (CornerRadius * 2), YPosition);
                Path.AddArc(XPosition + Width - (CornerRadius * 2), YPosition, CornerRadius * 2, CornerRadius * 2, 270, 90);
                Path.AddLine(XPosition + Width, YPosition + CornerRadius, XPosition + Width, YPosition + Height - (CornerRadius * 2));
                Path.AddArc(XPosition + Width - (CornerRadius * 2), YPosition + Height - (CornerRadius * 2), CornerRadius * 2, CornerRadius * 2, 0, 90);
                Path.AddLine(XPosition + Width - (CornerRadius * 2), YPosition + Height, XPosition + CornerRadius, YPosition + Height);
                Path.AddArc(XPosition, YPosition + Height - (CornerRadius * 2), CornerRadius * 2, CornerRadius * 2, 90, 90);
                Path.AddLine(XPosition, YPosition + Height - (CornerRadius * 2), XPosition, YPosition + CornerRadius);
                Path.AddArc(XPosition, YPosition, CornerRadius * 2, CornerRadius * 2, 180, 90);
    
                Path.CloseFigure();
    
                dc.DrawPath(BoxPen, Path);
    
                LinearGradientBrush lgb = new LinearGradientBrush(new PointF(XPosition + (Width / 2), YPosition), new PointF(XPosition + (Width / 2), YPosition + Height), Color.RosyBrown, Color.Red);
    
                dc.FillPath(lgb, Path);
    
            }
    }
