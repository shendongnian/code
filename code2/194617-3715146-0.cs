    delegate int D(int x);
    ...
    class C
    {
        void M(int y)
        {
            int z = 123;
            D d = x=>x+y+z;
            Console.WriteLine(d(10));
        }
    }
