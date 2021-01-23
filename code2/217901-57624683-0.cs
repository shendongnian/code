        public static bool IsPointInPolygon(Point point, IList<Point> polygon)
        {
            var intersects = new List<int>();
            var a = polygon.Last();
            foreach (var b in polygon)
            {
                if (b.X == point.X && b.Y == point.Y)
                {
                    return true;
                }
                if (b.X == a.X && point.X == a.X && point.X >= Math.Min(a.Y, b.Y) && point.Y <= Math.Max(a.Y, b.Y))
                {
                    return true;
                }
                if (b.Y == a.Y && point.Y == a.Y && point.X >= Math.Min(a.X, b.X) && point.X <= Math.Max(a.X, b.X))
                {
                    return true;
                }
                if ((b.Y < point.Y && a.Y >= point.Y) || (a.Y < point.Y && b.Y >= point.Y))
                {
                    var px = (int)(b.X + 1.0 * (point.Y - b.Y) / (a.Y - b.Y) * (a.X - b.X));
                    intersects.Add(px);
                }
                a = b;
            }
            intersects.Sort();
            return intersects.IndexOf(point.X) % 2 == 0 || intersects.Count(x => x < point.X) % 2 == 1;
        }
