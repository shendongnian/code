    public class Test
    {
        static double round(double what, double to)
        {
            return to * Math.Round(what/to);
        }
        public static void Main()
        {
            Console.WriteLine(round(3.5, 1));
            Console.WriteLine(round(3.44, 1));
            Console.WriteLine(round(3.44, 0.1));
            Console.WriteLine(round(1.68, 0.33));
        }
    }
