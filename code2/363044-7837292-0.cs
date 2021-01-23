    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            int b = 100;
            Test testclass = new Test();
            testclass.outTestMethod(a,out b); 
        }
    }
    class Test
    {
        public void outTestMethod(int x, out int y)
        {
            y = x;
        }
    }
