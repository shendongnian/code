    private static int scale = 1000; //your desired precision
            public static List<List<IntPoint>> ConvertToClipperPolygons(GraphicsPath path)
        {
            var Polygon = new List<IntPoint>();
            var Polygons = new List<List<IntPoint>>();
            var it = new GraphicsPathIterator(path);
            it.Rewind();
            bool isClosed;
            int startIndex;
            int endIndex;
            for (int i = 0; i < it.SubpathCount; i++)
            {
                var PointCount = it.NextSubpath(out startIndex, out endIndex, out isClosed);
                var Points = new PointF[PointCount];
                var Types = new byte[PointCount];
                it.CopyData(ref Points, ref Types, startIndex, endIndex);
                Polygons.Add(new List<IntPoint>(Points.Select(x => new IntPoint(Convert.ToInt64(x.X * scale), Convert.ToInt64(x.Y * scale)))));
            }
            it.Dispose();
            return Polygons;
        }
