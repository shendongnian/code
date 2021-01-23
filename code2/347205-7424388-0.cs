    using System;
    
    interface IParent {}
    abstract class Parent : IParent {}
    
    class Example : Parent
    {
        static void Main()
        {
            Console.WriteLine(new Example() is IParent);
        }
    }
