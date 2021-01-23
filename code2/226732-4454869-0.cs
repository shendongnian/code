    using System;
    using MyAlias = System.Int32;
    
    namespace UsingAlias
    {
        class Program
        {
            static void Main(string[] args)
            {
                MyAlias temp = Math.Min(10, 5);
                Console.WriteLine(temp);
    
                MyAlias result = MyAlias.Parse("42");
                Console.WriteLine(result);
            }
        }
    }
