    namespace OptionalAndNamedParameters
    {
        class Program
        {
            static void Main(string[] args)
            {
                //M(1, b: 2, 3, 4);
                //M(1, b: 2, c: 3, 4);
                M(1, c: 2, b: 3, 4);//red squiggly line under 'c' and error
            }
            private static void M(int a, int b, int c, int d)
            {
                Console.WriteLine(a+b+c+d);
            }
        }
    }
