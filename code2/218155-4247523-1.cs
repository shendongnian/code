    using System;
    
    namespace SomeApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                foreach(MyEnum target in Enum.GetValues(typeof(MyEnum)))
                {
                    Console.WriteLine(target.ToString());
                    // You can obviously perform an action on each one here.
                }
            }
        }
        
        enum MyEnum
        {
            One,
            Two,
            Three,
            Four,
            Five
        };
    }
    /*
    Prints...
    One
    Two
    Three
    Four
    Five
    */
