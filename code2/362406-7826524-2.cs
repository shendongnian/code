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
                    if (RectIntersectsLine(rect, line))
                    {
                        Rectangle r = new Rectangle
                        {
                            Width = rect.Width,
                            Height = rect.Height,
                            Fill = this.Color,
                            Opacity = 1,
                        };
                        Canvas.SetLeft(r, rect.X);
                        Canvas.SetTop(r, rect.Y);
                        paint.Children.Add(r);
                    }
                }
            }
            this.OriginPoint = this.DestinationPoint;
        }
