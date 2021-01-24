    class Program
    {
        static double Angle(double x1, double y1, double x2, double y2)
        {
            double angle1 = Math.Atan2(y1, x1);
            double angle2 = Math.Atan2(y2, x2);
            return Math.Abs(angle1 - angle2) * 180 / Math.PI;
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"Angle: {Angle(1, 0, 0, 1)}");
        }
    }
