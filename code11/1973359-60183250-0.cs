    using System;
    public class BaseClass
    {
        protected int number = 10;
    }
    public class DerivedClass : BaseClass
    {
        public void Print()
        {
            this.number = 20;  // you access it as a private filed 
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
