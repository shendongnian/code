c#
namespace Classes
{
    public class AppGeoPoint
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
}
And the function converted 
c#
        public static Classes.AppGeoPoint getClosestPointOnLines(Classes.AppGeoPoint pXy, Classes.AppGeoPoint[] aXys)
        {
            double? minDist = null;
            double fTo = 0.0;
            double fFrom;
            double x = 0.0;
            double y = 0.0;
            int i = 0;
            double dist;
            if (aXys.Length > 1)
            {
                for (var n = 1; n < aXys.Length; n++)
                {
                    if (aXys[n].X != aXys[n - 1].X)
                    {
                        var a = (aXys[n].Y - aXys[n - 1].Y) / (aXys[n].X - aXys[n - 1].X);
                        var b = aXys[n].Y - a * aXys[n].X;
                        dist = Math.Abs(a * pXy.X + b - pXy.Y) / Math.Sqrt(a * a + 1);
                    }
                    else
                        dist = Math.Abs(pXy.X - aXys[n].X);
                    // length^2 of line segment 
                    double rl2 = Math.Pow(aXys[n].Y - aXys[n - 1].Y, 2) + Math.Pow(aXys[n].X - aXys[n - 1].X, 2);
                    // distance^2 of pt to end line segment
                    double ln2 = Math.Pow(aXys[n].Y - pXy.Y, 2) + Math.Pow(aXys[n].X - pXy.X, 2);
                    // distance^2 of pt to begin line segment
                    double lnm12 = Math.Pow(aXys[n - 1].Y - pXy.Y, 2) + Math.Pow(aXys[n - 1].X - pXy.X, 2);
                    // minimum distance^2 of pt to infinite line
                    double dist2 = Math.Pow(dist, 2);
                    // calculated length^2 of line segment
                    double calcrl2 = ln2 - dist2 + lnm12 - dist2;
                    // redefine minimum distance to line segment (not infinite line) if necessary
                    if (calcrl2 > rl2)
                        dist = Math.Sqrt(Math.Min(ln2, lnm12));
                    if ((minDist == null) || (minDist > dist))
                    {
                        if (calcrl2 > rl2)
                        {
                            if (lnm12 < ln2)
                            {
                                fTo = 0;//nearer to previous point
                                fFrom = 1;
                            }
                            else
                            {
                                fFrom = 0;//nearer to current point
                                fTo = 1;
                            }
                        }
                        else
                        {
                            // perpendicular from point intersects line segment
                            fTo = ((Math.Sqrt(lnm12 - dist2)) / Math.Sqrt(rl2));
                            fFrom = ((Math.Sqrt(ln2 - dist2)) / Math.Sqrt(rl2));
                        }
                        minDist = dist;
                        i = n;
                    }
                }
                var dx = aXys[i - 1].X - aXys[i].X;
                var dy = aXys[i - 1].Y - aXys[i].Y;
                x = aXys[i - 1].X - (dx * fTo);
                y = aXys[i - 1].Y - (dy * fTo);
            }
            return new Classes.AppGeoPoint { X = x, Y = y };
        }
Then finally, to build an array list and check for the closest point
c#
            Classes.AppGeoPoint YourLocation= new Classes.AppGeoPoint { X = 50.83737, Y = -1.07428 };
            Classes.AppGeoPoint[] AreaCheck = new[] {
                new Classes.AppGeoPoint { X = 50.847550000000005, Y = -1.0863200000000002 },
                new Classes.AppGeoPoint { X = 50.83975, Y = -1.0859800000000002 },
                new Classes.AppGeoPoint { X = 50.83845, Y = -1.06487 },
                new Classes.AppGeoPoint { X = 50.84723, Y = -1.0645200000000001 }
            };
            Classes.AppGeoPoint ReturnVal = getClosestPointOnLines(YourLocation, AreaCheck);
            Console.WriteLine("X " + ReturnVal.X);
            Console.WriteLine("Y " + ReturnVal.Y);
ReturnVal.X and ReturnVal.Y will return the closest points latitude and longitude.
Hopefully, this may come in helpful to others.
