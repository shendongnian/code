    interface IA { void Method(int x); }
    interface IB { void Method(int x); }
    class A : IA, IB
    {
        void Method(int x)
        {
            Console.WriteLine(x);
        }
    }
