    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace RandomArrayTest
    {
        class MyClass
        {
            public int start;
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                MyClass[] a = new MyClass[10];
                for(int i=1; i<a.Length; i++)
                {
                    MyClass b = new MyClass();
                    a[i] = b;
                    a[i].start = 1;
                }
                
                MyFunction(a);
            }
    
            static void MyFunction(MyClass[] a)
            {
                for (int i = 1; i < a.Length; i++)
                {
                    int h = a[i].start;
                    Console.WriteLine(h);
                }
            }
        }
    }
