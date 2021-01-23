        private static void Method1(int x)
        {
            Console.WriteLine(x);
        }
        private static void Method2(int x)
        {
        }
        private static void Method3(int x)
        {
        }
        static void Main(string[] args)
        {
            Dictionary<int, Action<int>> methods = new Dictionary<int, Action<int>>();
            methods.Add(1, Method1);
            methods.Add(2,  Method2);
            methods.Add(3, Method3);
            (methods[1])(1);
        }
