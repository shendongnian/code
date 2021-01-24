    static void Main(string[] args)
    {
        List<PointF> points = new List<PointF>()
        {
            new PointF(6, 12),
            new PointF(6, 13.25f),
            new PointF(6, 14.5f),
            new PointF(6, 15.75f),
            new PointF(6, 17),
            new PointF(6, 18.25f),
            new PointF(18, 12),
            new PointF(18, 13.25f),
            new PointF(18, 14.5f),
            new PointF(18, 15.75f),
            new PointF(18, 17),
            new PointF(18, 18.25f)
        };
        var result = new List<List<PointF>>();
        for (int i = 0, j; i < points.Count; i += j)
        {
            for (j = 1; (i + j) < points.Count && IsInRange(points[i + j], points[i + j - 1]); j++) { }
            result.Add(points.GetRange(i, j).ToList());
        }
    }
    static bool IsInRange(PointF a, PointF b) => Math.Abs(b.X - a.X) < 1.26f && Math.Abs(b.Y - a.Y) < 1.26f;
