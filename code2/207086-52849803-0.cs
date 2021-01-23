    using System;
    
    namespace Playground
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                Console.WriteLine((int)new SomeResponse().Enum);
                Console.ReadLine();
            }
    
            public enum SomeEnum
            {
                Value1 = 1,
                Value2 = 2,
                Value3 = 3
            }
    
            public class SomeResponse
            {
                public SomeEnum Enum { get; set; }
            }
        }
    }
