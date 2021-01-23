    using System;
    struct Evil
    {
        public int Yeuch;
    }
    public class Program
    {
        public static void Main()
        {
            var pain = new Evil[] { new Evil { Yeuch = 2 } };
            pain[0].Yeuch = 27;
            Console.WriteLine(pain[0].Yeuch);
        }
    }
