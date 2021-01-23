    public static GraphicsPath Shrink(this GraphicsPath path, float width)
    {
        using (var p = new GraphicsPath())
        {
            p.AddPath(path, false);
            p.CloseAllFigures();
            p.Widen(new Pen(Color.Black, width*2));
                
            var position = 0;
            var result = new GraphicsPath();
            while (position < p.PointCount)
            {
                // skip outer edge
                position += CountNextFigure(p.PathData, position);
                // count inner edge
                var figureCount = CountNextFigure(p.PathData, position);
                var points = new PointF[figureCount];
                var types = new byte[figureCount];
                Array.Copy(p.PathPoints, position, points, 0, figureCount);
                Array.Copy(p.PathTypes, position, types, 0, figureCount);
                position += figureCount;
                result.AddPath(new GraphicsPath(points, types), false);
            }
            path.Reset();
            path.AddPath(result, false);
            return path;
        }
    }
    static int CountNextFigure(PathData data, int position)
    {
        int count = 0;
        for (var i = position; i < data.Types.Length; i++)
        {
            count++;
            if (0 != (data.Types[i] & (int) PathPointType.CloseSubpath))
            {
                return count;
            }
        }
        return count;
    }
