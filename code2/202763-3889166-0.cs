    namespace ConsoleApplication2
    {
    class myclass
    {
        public unsafe void swap(int *x, int *y)
        {
            unsafe
            {
                int temp = 0;
                temp = *x;
                *x = *y;
                *y = temp;
                Console.WriteLine("Using Swap1");
                Console.WriteLine("x:"+*x);
                Console.WriteLine("y:" + *y);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            unsafe
            {
                int x = 10;
                int y = 20;
                int* t1 = &x;
                int* t2 = &y;
                myclass m1 = new myclass();
                m1.swap(t1,t2);
                Console.WriteLine("Main");
                Console.WriteLine("x: " + x);
                Console.WriteLine("y: " + y);
                Console.ReadLine();
            }
        }
    }
}
