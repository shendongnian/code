    using System;
    public class Test
    {
            private static void assign(ref int i)
            {
                 i = 42;
            }
    
            public static void Main()
            {
                  var vars = new [] { 1,2,3,4 };
                  Console.WriteLine(vars[2]);
                  assign(ref vars[2]);
                  Console.WriteLine(vars[2]);
            }
    }
