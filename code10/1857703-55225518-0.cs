    public static class ApplicationExensions
    {
        // more (rather than less)
        // does not do headers and footers
        public static Range GetCurrentlyVisibleRange(this Application application)
        {
            try
            {
                Window activeWindow = application.ActiveWindow;
                var left = application.PointsToPixels(activeWindow.Left);
                var top = application.PointsToPixels(activeWindow.Top);
                var width = application.PointsToPixels(activeWindow.Width);
                var height = application.PointsToPixels(activeWindow.Height);
                var usableWidth = application.PointsToPixels(activeWindow.UsableWidth);
                var usableHeight = application.PointsToPixels(activeWindow.UsableHeight);
                var startRangeX = left;// + (width - usableWidth);
                var startRangeY = top;// + (height - usableHeight);
                var endRangeX = startRangeX + width;//usableWidth;
                var endRangeY = startRangeY + height;//usableHeight;
                Range start = (Range) activeWindow.RangeFromPoint((int) startRangeX, (int) startRangeY);
                Range end = (Range) activeWindow.RangeFromPoint((int) endRangeX, (int) endRangeY);
                Range r = application.ActiveDocument.Range(start.Start, end.Start);
                return r;
            }
            catch (COMException)
            {
                return null;
            }
        }
    }
    public static class RangeExtensions
    {
        public static bool Intersects(this Range a, Range b)
        {
            return a.Start <= b.End && b.Start <= a.End;
        }
        public static Rectangle? GetCoordinates(this Range range)
        {
            try
            {
                Application application = range.Application;
                Window window = application.ActiveWindow;
                int left = 0;
                int top = 0;
                int width = 0;
                int height = 0;
                window.GetPoint(out left, out top, out width, out height, range);
                return new Rectangle(left, top, width, height);
            }
            catch (COMException e)
            {
                return null;
            }
        }
    }
