       public class BigGrid : Canvas
        {
            private const int size = 3; // do something less hardcoded
    
            public BigGrid()
            {
            }
    
            protected override void OnRender(DrawingContext dc)
            {
                Pen pen = new Pen(Brushes.Black, 0.1);
    
                // vertical lines
                double pos = 0;
                int count = 0;
                do
                {
                    dc.DrawLine(pen, new Point(pos, 0), new Point(pos, DesiredSize.Height));
                    pos += size;
                    count++;
                }
                while (pos < DesiredSize.Width);
    
                string title = count.ToString();
    
                // horizontal lines
                pos = 0;
                count = 0;
                do
                {
                    dc.DrawLine(pen, new Point(0, pos), new Point(DesiredSize.Width, pos));
                    pos += size;
                    count++;
                }
                while (pos < DesiredSize.Height);
                // display the grid size (debug mode only!)
                title += "x" + count;
                dc.DrawText(new FormattedText(title, CultureInfo.InvariantCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 20, Brushes.White), new Point(0, 0));
            }
    
            protected override Size MeasureOverride(Size availableSize)
            {
                return availableSize;
            }
        }
