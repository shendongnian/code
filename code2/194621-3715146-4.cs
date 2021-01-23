    delegate int D(int x);
    ...
    class C
    {
        void M(int y)
        {
            int z = 123;
            D d = x=>x+y+z;
            Console.WriteLine(d(10));
            z = 345;
            y = 789;
            Console.WriteLine(d(10));
       }
    }
