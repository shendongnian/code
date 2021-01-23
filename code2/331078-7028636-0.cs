    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication2
    {
        public class Base
        {
            public Base()
                : this(null, null)
            {
            }
            public Base(string param1)
                : this(param1, null)
            {
            }
            public Base(string param1, string param2)
            {
                Console.WriteLine("Base Class: " + param1 + "+" + param2);
    
                if (param1 != null)
                {
                    // initialise param1
                }
                if (param2 != null)
                {
                    // initialise param2
                }
            }
        }
    
        public class Derived : Base
        {
            public Derived()
                : this("", "")
            {
            }
            public Derived(string param1)
                : this(param1, "")
            {
            }
            public Derived(string param1, string param2)
                : base(param1, param2)
            {
                Console.WriteLine("Derived Class: " + param1 + "+" + param2);
            }
        } 
        class Program
        {
            static void Main(string[] args)
            {
                Derived d = new Derived("test1", "test2");
                Console.ReadLine();
            }
        }
    }
