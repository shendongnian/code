    class Program
    {
        static int f(int x) { return x + 1; }
        static void g(int x, int y) { Console.WriteLine("hallo"); }
        static void Main(string[] args)
        {
            List<object> l = new List<object>();
            l.Add((Func<int, int>)f);
            l.Add((Action<int, int>)g);
            int r = ((Func<int, int>)l[0])(5);
            ((Action<int, int>)l[1])(0, 0);
        }
    }
