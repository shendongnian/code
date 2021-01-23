        void FingerMove(object sender, MouseEventArgs e)
        {
            if (this.IsDrawing)
            {
                this.DestinationPoint = e.GetPosition(paint);
                LineSegment line = new LineSegment
                {
                    X1 = this.DestinationPoint.X,
                    Y1 = this.DestinationPoint.Y,
                    X2 = this.OriginPoint.X,
                    Y2 = this.OriginPoint.Y
                };
                foreach (var rect in _rects)
                {
                    var x = Canvas.GetLeft(rect);
                    var y = Canvas.GetTop(rect);
                    if (RectIntersectsLine(new Rect(x, y, rect.Width, rect.Height) , line))
                    {
                        rect.Opacity = 1;
                        rect.Fill = Color;
                    }
                }
            }
            this.OriginPoint = this.DestinationPoint;
        }
