    class Program
    {
        static void Main(string[] args)
        {
            int x = 13;
            var ans = x.Cube().Half().Square();
            Console.WriteLine(ans);
        }
    }
    
    static class IntExtensions
    {
        public static int Half(this int source)
        {
            return source / 2;
        }
        public static int Cube(this int source)
        {
            return (int)Math.Pow(source, 3);
        }
        public static int Square(this int source)
        {
            return (int)Math.Pow(source, 2);
        }
    }
