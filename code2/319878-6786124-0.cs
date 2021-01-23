    using System;
    class App
    {
        class Foo 
        {
            readonly int x;
            public Foo() {  x = 1; Frob(); x = 2; Frob(); }
            void Frob() { Console.WriteLine(x); }
        }
        static void Main()
        {
            new Foo();
        }
    }
