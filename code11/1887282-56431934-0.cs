    using System;
    public class Parent 
    {
        public virtual void foo() 
        {
            Console.WriteLine("Parent");
        }
    }
    public class Child : Parent
    {
        public override void foo() 
        {
            Console.WriteLine("Child");
        }
    }
