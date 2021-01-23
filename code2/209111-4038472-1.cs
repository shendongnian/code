        protected override void OnRender(DrawingContext c)
        {
            base.OnRender(c);
            Pen pen = new Pen(Brushes.Black, 1);
            double h = this.ActualHeight;
            double d = pen.Thickness / 2;
            foreach (double x in new double[] { 7, 14 })
            {
                GuidelineSet g = new GuidelineSet(new double[] { x + d },
                                                  new double[] { 0 + d, h + d });
                c.PushGuidelineSet(g);
                c.DrawLine(pen, new Point(x, 0), new Point(x, h));
                c.Pop();
            }
        }
