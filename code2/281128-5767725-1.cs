    static class A
    {
        private static int x = InitX();
        static A()
        {
            Console.WriteLine("A()");
        }
        private static int InitX()
        {
            Console.out.WriteLine("InitX()");
            return 0;
        }
        ...
    }
