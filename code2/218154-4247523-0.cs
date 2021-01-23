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
