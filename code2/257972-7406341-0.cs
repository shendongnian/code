    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Drawing;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Origin of the point
                Point myPoint = new Point(4, 6);
                // Degrees to rotate the point
                float degree = 36.0F;
                PointF newPoint = RotatePoint(degree, myPoint);
                
                System.Console.WriteLine(newPoint.ToString());
                System.Console.ReadLine();
            }
            public static PointF RotatePoint(float angle, Point pt)
            {
                var a = angle * System.Math.PI / 180.0;
                float cosa = (float)Math.Cos(a);
                float sina = (float)Math.Sin(a);
                PointF newPoint = new PointF((pt.X * cosa - pt.Y * sina), (pt.X * sina + pt.Y * cosa));
                return newPoint;
            }
        }
    }
