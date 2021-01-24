    using System;
    namespace CoreApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string x = "shark";
                Console.WriteLine("Main: " + x);
                func2(); // If you comment this out, then the  below call to func2() outputs "sharp" instead of "shark"
                func1();
                Console.WriteLine("Main: " + x);
                func2();
            }
            static void func1()
            {
                string x = "shark";
                string y = x.Substring(0);
                unsafe
                {
                    fixed (char* c = y)
                    {
                        c[4] = 'p';
                    }
                }
                Console.WriteLine("func1(): " + x);
            }
            static void func2()
            {
                string x = "shark";
                Console.WriteLine("func2(): " + x);
            }
        }
    }
