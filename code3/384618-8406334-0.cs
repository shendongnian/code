            List<Point> Points = new List<Point>();
            foreach (UIElement x in cvsMain.Children.Where(ui => ui.GetType() == typeof(Rectangle)))
            {
                // Obtain transform information based off element you need to find position within
                GeneralTransform gt = x.TransformToVisual(cvsMain);
                // Find the four corners of the element
                Points.Add(gt.Transform(new Point(0, 0)));
                Points.Add(gt.Transform(new Point((x as Rectangle).Width, 0)));
                Points.Add(gt.Transform(new Point(0, (x as Rectangle).Height)));
                Points.Add(gt.Transform(new Point((x as Rectangle).Width, (x as Rectangle).Height)));
            }
            Double Left = Points.Min(p => p.X);
            Double Right = Points.Max(p => p.X);
            Double Top = Points.Min(p => p.Y);
            Double Bottom = Points.Max(p => p.Y);
