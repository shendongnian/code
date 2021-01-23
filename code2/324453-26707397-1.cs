        private static void AddToFirst<T>(ref T first, params dynamic[] args)
        {
            foreach (var arg in args)
            {
                first += arg;
            }
        }
        static void Main(string[] args)
        {
            int x = 0;
            AddToFirst(ref x,1,1.5,2.0,3.5,2);
            Console.WriteLine(x);
            double y = 0;
            AddToFirst(ref y, 1, 1.5, 2.0, 3.5, 2);
            Console.WriteLine(y);
            Console.ReadKey();
        }
