    class Program
    {
        public static void Print(int Lower, int Upper, int Step)
        {
            Func<int, bool> checkBounds = (i) => i <= Upper;
            if (Step < 0)
            {
                Swap(ref Lower, ref Upper);
                checkBounds = (i) => i >= Upper;
            }
            for (int i = Lower; checkBounds(i); i += Step)
                Console.Write($"{i} ");
        }
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
        static void Main(string[] args)
        {
            // assume these 3 come from user input
            int Lower = 2;
            int Upper = 10;
            int Step = -2;
            Print(Lower, Upper, Step);
        }
    }
