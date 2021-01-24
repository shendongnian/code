    using System;
    public class BaseClass
    {
        protected int number = 10;
    }
    public class DerivedClass: BaseClass
    {   
        public void Print()
        {
            Console.WriteLine(number); 
        }
    }
    class Program
    {
        public static void Main()
        {
            DerivedClass obj2 = new DerivedClass();
            obj2.Print();
        }
    }
