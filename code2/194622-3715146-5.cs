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
            // Initialize the closure class:
            Locals locals = new Locals();
            locals.y = y;
            // Transform the body so that all usages of y, z and the lambda
            // refer to the closure class:
            locals.z = 123;
            D d = locals.A;
            Console.WriteLine(d(10)); // Calls locals.A(10)
            locals.z = 345;
            locals.y = 789;
            Console.WriteLine(d(10)); // Calls locals.A(10)
        }
    }
