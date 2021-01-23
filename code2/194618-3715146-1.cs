    delegate int D(int x);
    ...
    class C
    {  
        private class Locals
        {
            public int y;
            public int z;
            public int A(int x)
            {
                return x + this.y + this.z;
            }
        }
        void M(int y)
        {
            Locals locals = new Locals();
            locals.y = y;
            locals.z = 123;
            D d = locals.A;
            Console.WriteLine(d(10)); // Calls locals.A(10)
        }
    }
