         PolyCurve ArcsAndLines(List<Point3d> points)
        {
            var curve = new PolyCurve();
            Arc current = Arc.Unset;
            for (int i = 0; i < points.Count - 1; i++)
            {
                var areEqual = false;
                if (i + 3 < points.Count)
                {
                    var arcA = new Arc(points[i], points[i + 1], points[i + 2]);
                    var arcB = new Arc(points[i], points[i + 1], points[i + 3]);
                    areEqual = AreEqual(arcA, arcB);
                }
                if (areEqual)
                {
                    var start = current == Arc.Unset ? points[i] : current.StartPoint;
                    current = new Arc(start, points[i + 1], points[i + 3]);
                }
                else
                {
                    if (current != Arc.Unset)
                    {
                        curve.Append(current);
                        current = Arc.Unset;
                        i++;
                    }
                    else
                    {
                        curve.Append(new Line(points[i], points[i + 1]));
                    }
                }
            }
            return curve;
        }
        bool AreEqual(Arc a, Arc b)
        {
            const double tol = 0.001;
            bool sameRadius = Math.Abs(a.Radius - b.Radius) < tol;
            if (!sameRadius) return false;
            bool sameCenter = a.Center.DistanceTo(b.Center) < tol;
            return sameCenter;
        }
