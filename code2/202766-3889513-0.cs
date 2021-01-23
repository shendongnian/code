    class Program
    {
        static void Main(string[] args)
        {
            int x = 3;
            int y = 6;
            Console.Write(string.Format("before swap x={0} y={1}", x, y));
            Swap(x, y);
            Console.Write(string.Format("after swap x={0} y={1}", x, y));
            Console.ReadKey();
        }
        static public unsafe void Swap(int a, int b)
        {
            int* ptrToA = &a;
            int* ptrToB = &b;
            int c = a;
            *ptrToB = c;
            *ptrToB = *ptrToA;
        }
    }
