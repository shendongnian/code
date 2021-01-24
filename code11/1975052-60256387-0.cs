    public class GridViewCustomPanel : Panel
    {
        private double maxWidth;
        private double maxHeight;
    
        protected override Size ArrangeOverride(Size finalSize)
        {
            var x = 0.0;
            var y = 0.0;
            foreach (var child in Children)
            {
                if ((maxWidth + x) > finalSize.Width)
                {
                    x = 0;
                    y += maxHeight;
                }
                var newpos = new Rect(x, y, maxWidth, maxHeight);
                child.Arrange(newpos);
                x += maxWidth;
            }
            return finalSize;
        }
    
        protected override Size MeasureOverride(Size availableSize)
        {
            foreach (var child in Children)
            {
                child.Measure(availableSize);
    
                var desirtedwidth = child.DesiredSize.Width;
                if (desirtedwidth > maxWidth)
                    maxWidth = desirtedwidth;
    
                var desiredheight = child.DesiredSize.Height;
                if (desiredheight > maxHeight)
                    maxHeight = desiredheight;
            }
            var itemperrow = Math.Floor(availableSize.Width / maxWidth);
            var rows = Math.Ceiling(Children.Count / itemperrow);
            return new Size(itemperrow * maxWidth, maxHeight * rows);
        }
    }
