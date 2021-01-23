    class A
    {
        public static void Foo()
        {
        }
    }
    class B : A
    {
        
    }
    class Program
    {
        static void main(string[] args)
        {
            B.Foo();
        }
    }
