    class Calculator
        {
            public static int Sum(int x,int y) => x + y;
            public static Func<int, int, int>  Add = (x, y) => x + y;
            public static Action<int,int> DisplaySum = (x, y) => Console.WriteLine(x + y);
        }
