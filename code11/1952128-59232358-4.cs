    class Program
    {
        static double Angle(double x1, double y1, double x2, double y2)
        {
            double angle1 = Math.Atan2(y1, x1);
            double angle2 = Math.Atan2(y2, x2);
            double angle = Math.Abs(angle1 - angle2) * 180 / Math.PI;
            return angle;
        }
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.Write("Enter first X value: ");
            float point1X = float.Parse(Console.ReadLine());
            Console.Write("Enter first Y value: ");
            float point1Y = float.Parse(Console.ReadLine());
            Console.Write("Enter second X value: ");
            float point2X = float.Parse(Console.ReadLine());
            Console.Write("Enter second Y value: ");
            float point2Y = float.Parse(Console.ReadLine());
           
            Console.WriteLine($"\nAngle between these points is {Angle(point1X, point1Y, point2X, point2Y)} degrees.");
        }
    }
