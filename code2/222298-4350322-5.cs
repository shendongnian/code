    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("cos(.25d) = {0}", MathF.Cos(.25d));
            Console.WriteLine("sin(.25d) = {0}", MathF.Sin(.25d));
            Console.ReadKey();
        }
    }
    public static class MathF
    {
        public static Func<double, float> Cos = angleR => (float)Math.Cos(angleR);
        public static Func<double, float> Sin = angleR => (float)Math.Sin(angleR);
    }
