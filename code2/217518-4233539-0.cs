    class Program
    {
        static void Main()
        {
            // store
            var dico = new Dictionary<int, Delegate>();
            dico[1] = new Func<int, int, int>(Func1);
            dico[2] = new Func<int, int, int, int>(Func2);
    
            // and later invoke
            var res = dico[1].DynamicInvoke(1, 2);
            Console.WriteLine(res);
            var res2 = dico[2].DynamicInvoke(1, 2, 3);
            Console.WriteLine(res2);
        }
    
        public static int Func1(int arg1, int arg2)
        {
            return arg1 + arg2;
        }
    
        public static int Func2(int arg1, int arg2, int arg3)
        {
            return arg1 + arg2 + arg3;
        }
    }
