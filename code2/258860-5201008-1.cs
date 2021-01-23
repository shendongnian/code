    using System;
    
    class Program {
        static void Main(string[] args) {
            new Test();
        }
    }
    
    class Test {
        ~Test() { Console.Beep(); }
    }
