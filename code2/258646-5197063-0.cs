            WriteableBitmap wb = new WriteableBitmap(600, 600);
            Polygon p = new Polygon();
            p.Points = new PointCollection() { new Point(10, 10), new Point(77, 500), new Point(590, 100), new Point(250, 590), new Point(300, 410) };
            p.Fill = new LinearGradientBrush()
            {
                //Gradient angle is 0,0 to 1,1 by default
                GradientStops = new GradientStopCollection() { 
                    new GradientStop() { Color = Colors.White, Offset = 0 }, 
                    new GradientStop() { Color = Colors.Red, Offset = 1 } }
            };
            
            wb.Render(p, null);
            wb.Invalidate();
            //Save WriteableBitmap as described in other questions
